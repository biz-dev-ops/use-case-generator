using Company.Product.Domain.UseCases.Types;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases
{
    public interface GetAnimalsUseCase
    {
        Task<IEnumerable<Animal>> GetAnimals(string filter, int limit, int offset);
    }
}