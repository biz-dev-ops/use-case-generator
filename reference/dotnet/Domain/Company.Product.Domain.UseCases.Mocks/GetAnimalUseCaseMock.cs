using Company.Product.Domain.UseCases.Types;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Mocks
{
    public class GetAnimalUseCaseMock : IGetAnimalUseCase
    {private readonly AnimalStore animalStore;

        public GetAnimalUseCaseMock(AnimalStore animalStore)
        {
            this.animalStore = animalStore ?? throw new ArgumentNullException(nameof(animalStore));
        }

        public Task<Animal> GetAnimal(Guid animalId, CancellationToken cancellationToken)
        {   
            return Task.FromResult(animalStore.Animals.First(a => a.AnimalId.Equals(animalId)));
        }
    }
}