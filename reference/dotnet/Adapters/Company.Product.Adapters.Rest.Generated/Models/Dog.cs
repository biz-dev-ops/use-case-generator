
namespace Company.Product.Adapters.Rest.Models;

public class Dog : Animal
{
    public string A { get; }

    public Dog(Guid animalId, string sound, string a) : base(animalId, sound)
    {
        A = a;
    }

    public override Domain.UseCases.Types.Animal ToDomain() => new Domain.UseCases.Types.Dog(animalId: AnimalId, sound: Sound, a: A);

    public static Dog FromDomain(Domain.UseCases.Types.Dog dog) => new Dog(animalId: dog.AnimalId, dog.Sound, dog.A);
}
