namespace Company.Product.Adapters.Rest.Models;

public class Dog : Animal
{
    public string A { get; set; }

    public override Domain.UseCases.Types.Animal ToDomain()
    {
        return new Domain.UseCases.Types.Dog(animalId: AnimalId, sound: Sound, a: A);
    }
}
