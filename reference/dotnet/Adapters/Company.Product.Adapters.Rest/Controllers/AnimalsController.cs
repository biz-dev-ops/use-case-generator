using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsController : AbstractAnimalsController
{
    public AnimalsController(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase) 
        : base(createAnimalUseCase, getAnimalUseCase, getAnimalsUseCase)
    { }

    public override async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, CreatedAtRoute>> CreateAnimal([FromBody, Required] Animal animal, CancellationToken cancellationToken)
    {
        await base.CreateAnimal(animal, cancellationToken);
        return TypedResults.CreatedAtRoute(routeName: nameof(GetAnimal), routeValues: new { animal.AnimalId });
    }

    public override async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery] int limit, [FromQuery] int offset, CancellationToken cancellationToken)
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

    public override Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal(Guid animalId, CancellationToken cancellationToken)
    {
        return base.GetAnimal(animalId, cancellationToken);
    }
}