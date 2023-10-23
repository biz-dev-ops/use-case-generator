using Company.Product.Domain.UseCases.Types;

using BizDevOps.Core.Attributes;
using System.Threading.Tasks;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    [UseCase]
    [Command]
    public interface ICreateAnimalUseCase
    {
       Task Execute(Animal animal, CancellationToken cancellationToken);
    }
}