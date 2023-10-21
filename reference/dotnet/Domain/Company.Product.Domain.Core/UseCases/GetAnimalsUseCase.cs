namespace Company.Product.Domain.Core.UseCases;

public class GetAnimalsUseCase : IGetAnimalsUseCase
{
    private readonly IGetTypesPort getTypesPort;

    public GetAnimalsUseCase(IGetTypesPort getTypesPort)
    {
        this.getTypesPort = getTypesPort ?? throw new ArgumentNullException(nameof(getTypesPort));
    }

    public Task<IEnumerable<Animal>> GetAnimals(string filter, int limit, int offset, CancellationToken cancellationToken)
    {
        dynamic f = new { Filter = filter, Limit = limit, Offset = offset};

        return getTypesPort.GetTypes(filter: f, cancellationToken: cancellationToken);
    }
}
