
namespace Company.Product.Adapters.Rest.Models;

public class Cow : Animal
{
    public string C { get; set; }

    public Cow(Guid animalId, string sound, string c) : base(animalId, sound)
    {
        C = c;
    }

    public override Domain.UseCases.Types.Animal ToDomain() => new Domain.UseCases.Types.Cow(animalId: AnimalId, sound: Sound, c: C);

    public static Cow FromDomain(Domain.UseCases.Types.Cow cow) => new Cow(animalId: cow.AnimalId, sound: cow.Sound, c: cow.C);
}
