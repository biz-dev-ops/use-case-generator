using Company.Product.Domain.UseCases.Types;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Mocks
{
    public class GetAnimalsUseCaseMock : IGetAnimalsUseCase
    {
        public Task<IEnumerable<Animal>> GetAnimals(string filter, int limit, int offset, CancellationToken cancellationToken)
        {
            var animals = new List<Animal>();
            switch(filter)
            {
                case "dog":
                    animals.Add(new Dog() {
                        Sound = "woef",
                        A = "bd33fdd5-9070-4321-a42a-fa86a7fe64f4"
                    });
                    break;
                case "cow":
                    animals.Add(new Cow() {
                        Sound = "mooooow",
                        C = "f0eee6af-b31f-4ea1-a295-00bf5006f936"
                    });
                    break;
                case "cat":
                    animals.Add(new Cat(){
                        Sound = "miauw",
                        B = "4a2b9889-2ca0-452c-ab42-34d093c0b2b5"
                    });
                    break;
            }

            return Task.FromResult(animals as IEnumerable<Animal>);
        }
    }
}