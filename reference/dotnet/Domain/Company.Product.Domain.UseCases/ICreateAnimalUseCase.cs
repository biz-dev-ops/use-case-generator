using Company.Product.Domain.UseCases.Types;
using Company.Product.Domain.UseCases.Exceptions;

using System.Threading.Tasks;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    public interface ICreateAnimalUseCase
    {

        /// <summary>Use case description.</summary>
        /// <param name="animal" cref="Animal">Parameter description.</param>
        /// <param name="cancellationToken">Parameter description.</param>
        /// <exception cref="NotAuthenticatedException">Exception description.</exception>
        /// <exception cref="NotAuthorizedException">Exception description.</exception>
        /// <exception cref="NotFoundException">Exception description.</exception>
        Task CreateAnimal(Animal animal, CancellationToken cancellationToken);
    }
}