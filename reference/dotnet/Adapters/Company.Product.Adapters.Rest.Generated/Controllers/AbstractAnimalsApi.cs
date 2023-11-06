namespace Company.Product.Adapters.Rest.Controllers;

public abstract class AbstractAnimalsApi : ControllerBase
{
    private readonly ICreateAnimalUseCase createAnimalUseCase;
    private readonly IGetAnimalUseCase getAnimalUseCase;
    private readonly IGetAnimalsUseCase getAnimalsUseCase;

    protected AbstractAnimalsApi(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase)
    {
        this.createAnimalUseCase = createAnimalUseCase ?? throw new ArgumentNullException(nameof(createAnimalUseCase));
        this.getAnimalUseCase = getAnimalUseCase ?? throw new ArgumentNullException(nameof(getAnimalUseCase));
        this.getAnimalsUseCase = getAnimalsUseCase ?? throw new ArgumentNullException(nameof(getAnimalsUseCase));
    }

    [HttpPost]
    [Route("/animals")]
    public async virtual Task<ActionResult> CreateAnimal([FromBody][Required] Animal animal, CancellationToken cancellationToken)
    {
        await createAnimalUseCase.CreateAnimal(animal: animal.ToDomain(), cancellationToken: cancellationToken);
        return Empty;
    }

    [HttpGet]
    [Route("/animals")]
    public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery] int limit, [FromQuery] int offset, CancellationToken cancellationToken)
    {
        var animals = await getAnimalsUseCase.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        return new GetAnimalsResponse()
        {
            Animals = animals.Select(a => AnimalMapper.FromDomain(a))
        };
    }

    [HttpGet]
    [Route("/animals/{animalId}")]
    public async virtual Task<ActionResult<GetAnimalResponse>> GetAnimal(Guid animalId, CancellationToken cancellationToken)
    {
        var animal = await getAnimalUseCase.GetAnimal(animalId: animalId, cancellationToken: cancellationToken);

        return new GetAnimalResponse()
        {
            Animal = AnimalMapper.FromDomain(animal)
        };
    }
}
