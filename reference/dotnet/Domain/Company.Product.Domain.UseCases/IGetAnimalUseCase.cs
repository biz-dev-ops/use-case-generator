using Company.Product.Domain.UseCases.Types;

using BizDevOps.Core.Attributes;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Company.Product.Domain.UseCases
{
    [UseCase]
    [Query]
    public interface IGetAnimalUseCase
    {
       Task<Animal> GetAnimal(Guid animalId, CancellationToken cancellationToken);
    }
}