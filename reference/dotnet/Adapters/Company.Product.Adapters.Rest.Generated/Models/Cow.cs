namespace Company.Product.Adapters.Rest.Models;

public class Cow : Animal
{
    public string C { get; set; }

    public override Domain.UseCases.Types.Animal ToDomain()
    {
        return new Domain.UseCases.Types.Cow(animalId: AnimalId, sound: Sound, c: C);
    }
}
