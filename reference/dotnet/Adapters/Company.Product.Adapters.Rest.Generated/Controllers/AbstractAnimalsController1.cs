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
            return Map(animal);
    }

    [HttpGet]
    [Route("/animals")]
    public virtual async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
        var animals = await getAnimalsUseCase.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        return Map(limit: limit, offset: offset, useCaseResponse: animals.Select(Animal.FromDomain));
    }

    [HttpGet]
    [Route("/animals/{animalId}")]
    public virtual async Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal([FromRoute, Required] Guid animalId, CancellationToken cancellationToken)
    {
        var animal = await getAnimalUseCase.GetAnimal(animalId: animalId, cancellationToken: cancellationToken);

        return Map(animalId: animalId, useCaseResponse: Animal.FromDomain(animal));
    }

    protected abstract Results<ForbidHttpResult, UnauthorizedHttpResult, Created> Map(Animal animal);
    protected abstract Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>> Map(Guid animalId, Animal useCaseResponse);
    protected abstract Results<ForbidHttpResult, UnauthorizedHttpResult, Ok<GetAnimalsResponse>> Map(int limit, int offset, IEnumerable<Animal> useCaseResponse);
}
