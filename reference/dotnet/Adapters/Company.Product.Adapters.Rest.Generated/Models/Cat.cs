namespace Company.Product.Adapters.Rest.Models;

public class Cat : Animal
{
    public string B { get; set; }

    public override Domain.UseCases.Types.Animal ToDomain()
    {
        return new Domain.UseCases.Types.Cat(animalId: AnimalId, sound: Sound, b: B);
    }
}
