using Company.Product.Domain.UseCases.Types;

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    public interface IGetAnimalUseCase
    {
       Task<Animal> GetAnimal(Guid animalId, CancellationToken cancellationToken);
    }
}