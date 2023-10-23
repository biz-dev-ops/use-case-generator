using Company.Product.Domain.UseCases;
using Company.Product.Domain.UseCases.Types;

namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsApi : AbstractAnimalsApi
{

    public AnimalsApi(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase) 
        : base(createAnimalUseCase, getAnimalUseCase, getAnimalsUseCase)
    { }

    public override async Task<ActionResult> CreateAnimal([FromBody, Required] Animal animal, CancellationToken cancellationToken)
    {
        await base.CreateAnimal(animal, cancellationToken);

        return CreatedAtAction(nameof(GetAnimal), new { animal.AnimalId }, null);
    }

    public override async Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
        var response = await base.GetAnimals(limit: limit, offset: offset, cancellationToken: cancellationToken);

        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(response));
        

        response.Value.Links = new OffsetResponseLinks()
        {
            Next = Url.Action(
                action: nameof(GetAnimals),
                values: new { limit, offset = offset + limit }
            ),
        };

        return response;
    }
    public override async Task<ActionResult<GetAnimalResponse>> GetAnimal(Guid animalId, CancellationToken cancellationToken)
    {
        var response = await base.GetAnimal(animalId, cancellationToken);

        return response;
    }
}