
namespace Company.Product.Adapters.Rest.Models;

public class Cat : Animal
{
    public string B { get; }

    public Cat(Guid animalId, string sound, string b) : base(animalId, sound)
    {
        B = b;
    }

    public override Domain.UseCases.Types.Animal ToDomain() => new Domain.UseCases.Types.Cat(animalId: AnimalId, sound: Sound, b: B);

    public static Cat FromDomain(Domain.UseCases.Types.Cat cat) => new Cat(animalId: cat.AnimalId, sound: cat.Sound, b: cat.B);
}
