namespace Company.Product.Adapters.Rest.Controllers;

public class AnimalsApi : AbstractAnimalsApi
{
    public AnimalsApi(GetAnimalsUseCase getAnimalsUseCase) 
        : base(getAnimalsUseCase)
    { }

    public override async Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery, Required] string filter, [FromQuery, Required] int limit, [FromQuery, Required] int offset)
    {
        var response = await base.GetAnimals(filter, limit, offset);

        response.Value.Links = new OffsetResponseLinks()
        {
            Next = Url.Action(nameof(GetAnimals), new { filter = filter, limit = limit, offset = offset + 1 }),
        };

        return response;
    }
}