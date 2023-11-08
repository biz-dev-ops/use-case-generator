namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsController : AbstractAnimalsController1
{
    public AnimalsController(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase) 
        : base(createAnimalUseCase, getAnimalUseCase, getAnimalsUseCase)
    { }

    public override async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, Created>> CreateAnimal([FromBody, Required] Animal animal, CancellationToken cancellationToken)
    {
        await base.CreateAnimal(animal, cancellationToken);
        var location = Url.Action(
            action: nameof(GetAnimal),
            values: new { animal.AnimalId }
        );
        return TypedResults.Created(location);
    }

    public override async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
        var results = await base.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        var ok = (Ok<GetAnimalsResponse>)results.Result;
        
        ok.Value.Links = new OffsetResponseLinks()
        {
            Next = Url.Action(
                action: nameof(GetAnimals),
                values: new { limit, offset = offset + limit }
            )
        };

        return results;
    }

    public override Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal([FromRoute, Required] Guid animalId, CancellationToken cancellationToken)
    {
        return base.GetAnimal(animalId, cancellationToken);
    }
}