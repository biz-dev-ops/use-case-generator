using Company.Product.Domain.UseCases.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Mocks
{
    public class GetAnimalsUseCaseMock : IGetAnimalsUseCase
    {
        private readonly AnimalStore animalStore;

        public GetAnimalsUseCaseMock(AnimalStore animalStore)
        {
            this.animalStore = animalStore ?? throw new ArgumentNullException(nameof(animalStore));
        }

        public Task<IEnumerable<Animal>> Execute(int limit, int offset, CancellationToken cancellationToken)
        {
            return Task.FromResult(animalStore.Animals.Skip(offset).Take(limit));
        }
    }
}