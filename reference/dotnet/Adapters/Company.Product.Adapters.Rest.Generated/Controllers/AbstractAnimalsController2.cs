namespace Company.Product.Adapters.Rest.Controllers;

public abstract class AbstractAnimalsController2 : ControllerBase
{
    [HttpPost]
    [Route("/animals")]
    public abstract Task<Results<ForbidHttpResult, UnauthorizedHttpResult, Created>> CreateAnimal([FromBody, Required] Animal animal, CancellationToken cancellationToken);

    [HttpGet]
    [Route("/animals")]
    public abstract Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalsResponse>>> GetAnimals([FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken);

    [HttpGet]
    [Route("/animals/{animalId}")]
    public abstract Task<Results<ForbidHttpResult, UnauthorizedHttpResult, NotFound, Ok<GetAnimalResponse>>> GetAnimal([FromRoute, Required] Guid animalId, CancellationToken cancellationToken);
}
