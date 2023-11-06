
namespace Company.Product.Domain.Core.UseCases;

public class GetAnimalUseCase : IGetAnimalUseCase
{
    public Task<Animal> GetAnimal(Guid animalId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
