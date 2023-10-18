namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsApi : AbstractAnimalsApi
{
    public AnimalsApi(IBus bus) 
        : base(bus)
    { }

    public override async Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery, Required] string filter, [FromQuery, Required] int limit, [FromQuery, Required] int offset, CancellationToken cancellationToken)
    {
        var response = await base.GetAnimals(filter, limit, offset, cancellationToken);

        response.Value.Links = new OffsetResponseLinks()
        {
            Next = Url.Action(nameof(GetAnimals), new { filter, limit, offset = offset + limit }),
        };

        return response;
    }
}