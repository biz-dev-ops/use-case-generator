namespace Company.Product.Domain.Ports;

[Port]
[Query]
public interface IGetTypesPort
{
    public Task<IEnumerable<T>> GetTypes<T>(IQueryable<T> query, CancellationToken cancellationToken);


}