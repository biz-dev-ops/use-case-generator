using Company.Product.Domain.UseCases.Types;
using Company.Product.Domain.UseCases.Exceptions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases
{
    public interface IGetAnimalsUseCase
    {
        /// <summary>Use case description.</summary>
        /// <param name="limit">Parameter description.</param>
        /// <param name="offset">Parameter description.</param>
        /// <param name="cancellationToken">Parameter description.</param>
        /// <exception cref="NotAuthenticatedException">Exception description.</exception>
        /// <exception cref="NotAuthorizedException">Exception description.</exception>
        Task<IEnumerable<Animal>> GetAnimals(int limit, int offset, CancellationToken cancellationToken);
    }
}