namespace Company.Product.Domain.Ports;

[Port]
[Query]
public interface IGetTypesPort
{
    public Task<IEnumerable<T>> GetTypes<T>(dynamic filter, CancellationToken cancellationToken);
}
