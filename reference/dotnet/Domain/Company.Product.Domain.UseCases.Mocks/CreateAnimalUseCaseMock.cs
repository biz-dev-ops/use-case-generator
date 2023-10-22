using Company.Product.Domain.UseCases.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Mocks
{
    public class CreateAnimalUseCaseMock : ICreateAnimalUseCase
    {
        private readonly AnimalStore animalStore;

        public CreateAnimalUseCaseMock(AnimalStore animalStore)
        {
            this.animalStore = animalStore ?? throw new ArgumentNullException(nameof(animalStore));
        }

        public Task Execute(Animal animal, CancellationToken cancellationToken)
        {
            animalStore.Add(animal);
            return Task.CompletedTask;
        }
    }
}