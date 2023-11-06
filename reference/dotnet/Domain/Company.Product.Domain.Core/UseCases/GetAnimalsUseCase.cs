namespace Company.Product.Domain.Core.UseCases;

public class GetAnimalsUseCase : IGetAnimalsUseCase
{
    public Task<IEnumerable<Animal>> GetAnimals(int limit, int offset, CancellationToken cancellationToken)
    {
       throw new NotImplementedException();
    }
}
