

namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsController : AbstractAnimalsController1
{
    public AnimalsController(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase)
        : base(createAnimalUseCase, getAnimalUseCase, getAnimalsUseCase)
    { }

    protected override Results<ForbidHttpResult, UnauthorizedHttpResult, Created> Map(Animal animal)
    {
        var location = Url.Action(
            action: nameof(GetAnimal),
            values: new { animal.AnimalId }
        );

        return TypedResults.Created(location);
    }

    protected override Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>> Map(Guid animalId, Animal useCaseResponse)
    {
        if (Equals(useCaseResponse, default(Animal)))
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GetAnimalResponse()
        {
            Animal = useCaseResponse
        });
    }

    protected override Results<ForbidHttpResult, UnauthorizedHttpResult, Ok<GetAnimalsResponse>> Map(int limit, int offset, IEnumerable<Animal> useCaseResponse)
    {
        return TypedResults.Ok(new GetAnimalsResponse()
        {
            Animals = useCaseResponse,
            Links = new OffsetResponseLinks()
            {
                Next = Url.Action(
                    action: nameof(GetAnimals),
                    values: new { limit, offset = offset + limit }
                )
            }
        });
    }
}