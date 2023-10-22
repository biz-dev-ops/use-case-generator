using Company.Product.Domain.UseCases.Types;

using BizDevOps.Core.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases
{
    [UseCase]
    [Query]
    public interface IGetAnimalsUseCase
    {
       Task<IEnumerable<Animal>> Execute(string filter, int limit, int offset, CancellationToken cancellationToken);
    }
}