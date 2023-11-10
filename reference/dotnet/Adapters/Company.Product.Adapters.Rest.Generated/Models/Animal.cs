namespace Company.Product.Adapters.Rest.Models;

/*
 discriminator:
    propertyName: object_type
    mapping:
      "CAT": "#/cat"
      "COW": "#/cow"
      "DOG": "#/dog"
 */
[JsonPolymorphic(TypeDiscriminatorPropertyName = "objectType")]
[JsonDerivedType(typeof(Cat), "CAT")]
[JsonDerivedType(typeof(Cow), "COW")]
[JsonDerivedType(typeof(Dog), "DOG")]
public abstract class Animal
{
    private static AnimalVisitor visitor = new AnimalVisitor();
    public Guid AnimalId { get; }
    public string Sound { get; }

    protected Animal(Guid animalId, string sound)
    {
        AnimalId = animalId;
        Sound = sound;
    }

    public abstract Domain.UseCases.Types.Animal ToDomain();

    public static Animal FromDomain(Domain.UseCases.Types.Animal animal)
    {
        if (animal is null)
        {
            return null;
        }

        return animal.Visit(visitor);
    }

    private class AnimalVisitor : Domain.UseCases.Types.AnimalVisitor<Animal>
    {
        public Animal Visit(Domain.UseCases.Types.Cat cat) => Cat.FromDomain(cat);

        public Animal Visit(Domain.UseCases.Types.Cow cow) => Cow.FromDomain(cow);

        public Animal Visit(Domain.UseCases.Types.Dog dog) => Dog.FromDomain(dog);
    }
}
