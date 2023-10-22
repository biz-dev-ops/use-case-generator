namespace Company.Product.Domain.Core.UseCases;

public class GetAnimalsUseCase : IGetAnimalsUseCase
{
    private readonly IGetTypesPort getTypesPort;

    public GetAnimalsUseCase(IGetTypesPort getTypesPort)
    {
        this.getTypesPort = getTypesPort ?? throw new ArgumentNullException(nameof(getTypesPort));
    }

    public Task<IEnumerable<Animal>> Execute(string filter, int limit, int offset, CancellationToken cancellationToken)
    {
        IQueryable<Animal> query =  Enumerable.Empty<Animal>().AsQueryable()
            .Skip(offset)
            .Take(limit);

        return getTypesPort.GetTypes(query: query, cancellationToken: cancellationToken);
    }
}
