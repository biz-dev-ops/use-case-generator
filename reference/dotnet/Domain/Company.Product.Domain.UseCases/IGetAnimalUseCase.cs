using Company.Product.Domain.UseCases.Types;
using Company.Product.Domain.UseCases.Exceptions;

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    public interface IGetAnimalUseCase
    {
        /// <summary>Use case description.</summary>
        /// <param name="animalId">Parameter description.</param>
        /// <param name="cancellationToken">Parameter description.</param>
        /// <returns cref="Animal">Parameter description.</returns>
        /// <exception cref="NotAuthenticatedException">Exception description.</exception>
        /// <exception cref="NotAuthorizedException">Exception description.</exception>
        /// <exception cref="NotFoundException">Exception description.</exception>
        Task<Animal> GetAnimal(Guid animalId, CancellationToken cancellationToken);
    }
}