using Company.Product.Domain.UseCases;

namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsApi : AbstractAnimalsApi
{
    public AnimalsApi(IGetAnimalsUseCase getAnimalsUseCase)
        : base(getAnimalsUseCase)
    { }

    public override async Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery, Required] string filter, [FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
        var response = await base.GetAnimals(filter: filter, limit: limit, offset: offset, cancellationToken: cancellationToken);

        response.Value.Links = new OffsetResponseLinks()
        {
            Next = Url.Action(
                action: nameof(GetAnimals),
                values: new { filter, limit, offset = offset + limit }
            ),
        };

        return response;
    }
}