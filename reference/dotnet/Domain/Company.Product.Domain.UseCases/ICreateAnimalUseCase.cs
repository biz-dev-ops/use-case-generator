using Company.Product.Domain.UseCases.Types;

using System.Threading.Tasks;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    public interface ICreateAnimalUseCase
    {
       Task CreateAnimal(Animal animal, CancellationToken cancellationToken);
    }
}