namespace Company.Product.Adapters.Rest.Controllers;

public abstract class AbstractAnimalsController1 : ControllerBase
{
    private readonly ICreateAnimalUseCase createAnimalUseCase;
    private readonly IGetAnimalUseCase getAnimalUseCase;
    private readonly IGetAnimalsUseCase getAnimalsUseCase;

    protected AbstractAnimalsController1(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase)
    {
        this.createAnimalUseCase = createAnimalUseCase ?? throw new ArgumentNullException(nameof(createAnimalUseCase));
        this.getAnimalUseCase = getAnimalUseCase ?? throw new ArgumentNullException(nameof(getAnimalUseCase));
        this.getAnimalsUseCase = getAnimalsUseCase ?? throw new ArgumentNullException(nameof(getAnimalsUseCase));
    }

    [HttpPost]
    [Route("/animals")] 
    public virtual async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, Created>> CreateAnimal([FromBody, Required] Animal animal, CancellationToken cancellationToken)
    {
            await createAnimalUseCase.CreateAnimal(animal: animal.ToDomain(), cancellationToken: cancellationToken);
            return null;
    }

    [HttpGet]
    [Route("/animals")]
    public virtual async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
       var animals = await getAnimalsUseCase.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        var body = new GetAnimalsResponse()
        {
            Animals = animals.Select(Animal.FromDomain)
        };

        return TypedResults.Ok(body);
    }

    [HttpGet]
    [Route("/animals/{animalId}")]
    public virtual async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal([FromRoute, Required] Guid animalId, CancellationToken cancellationToken)
    {
        var animal = await getAnimalUseCase.GetAnimal(animalId: animalId, cancellationToken: cancellationToken);

        var body = new GetAnimalResponse()
        {
            Animal = Animal.FromDomain(animal)
        };

        return TypedResults.Ok(body);
    }
}
