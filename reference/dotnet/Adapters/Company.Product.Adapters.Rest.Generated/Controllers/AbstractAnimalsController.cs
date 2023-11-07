using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Company.Product.Adapters.Rest.Controllers;

public abstract class AbstractAnimalsController : ControllerBase
{
    private readonly ICreateAnimalUseCase createAnimalUseCase;
    private readonly IGetAnimalUseCase getAnimalUseCase;
    private readonly IGetAnimalsUseCase getAnimalsUseCase;

    protected AbstractAnimalsController(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase)
    {
        this.createAnimalUseCase = createAnimalUseCase ?? throw new ArgumentNullException(nameof(createAnimalUseCase));
        this.getAnimalUseCase = getAnimalUseCase ?? throw new ArgumentNullException(nameof(getAnimalUseCase));
        this.getAnimalsUseCase = getAnimalsUseCase ?? throw new ArgumentNullException(nameof(getAnimalsUseCase));
    }

    [HttpPost]
    [Route("/animals")]
    public async virtual Task<Results<ForbidHttpResult, UnauthorizedHttpResult, CreatedAtRoute>> CreateAnimal([FromBody][Required] Animal animal, CancellationToken cancellationToken)
    {
        await createAnimalUseCase.CreateAnimal(animal: animal.ToDomain(), cancellationToken: cancellationToken);
        return null;
    }

    [HttpGet]
    [Route("/animals")]
    public async virtual Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery] int limit, [FromQuery] int offset, CancellationToken cancellationToken)
    {
        var animals = await getAnimalsUseCase.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        var body = new GetAnimalsResponse()
        {
            Animals = animals.Select(a => AnimalMapper.FromDomain(a))
        };

        return TypedResults.Ok(body);
    }

    [HttpGet]
    [Route("/animals/{animalId}")]
    public async virtual Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal(Guid animalId, CancellationToken cancellationToken)
    {
        var animal = await getAnimalUseCase.GetAnimal(animalId: animalId, cancellationToken: cancellationToken);

        var body = new GetAnimalResponse()
        {
            Animal = AnimalMapper.FromDomain(animal)
        };

        return TypedResults.Ok(body);
    }
}
