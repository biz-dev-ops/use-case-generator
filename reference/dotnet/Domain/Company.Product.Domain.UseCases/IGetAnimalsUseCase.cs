using Company.Product.Domain.UseCases.Types;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases
{
    public interface IGetAnimalsUseCase
    {
       Task<IEnumerable<Animal>> GetAnimals(int limit, int offset, CancellationToken cancellationToken);
    }
}