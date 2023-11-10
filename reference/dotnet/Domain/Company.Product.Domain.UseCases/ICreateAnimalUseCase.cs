using Company.Product.Domain.UseCases.Types;

using System.Threading.Tasks;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
     /*
    throws:
        - NotAuthenticatedException
        - NotAuthorizedException
    */
    public interface ICreateAnimalUseCase
    {
       Task CreateAnimal(Animal animal, CancellationToken cancellationToken);
    }
}