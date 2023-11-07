namespace Company.Product.Adapters.Rest.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "objectType")]
[JsonDerivedType(typeof(Cat), "CAT")]
[JsonDerivedType(typeof(Cow), "COW")]
[JsonDerivedType(typeof(Dog), "DOG")]
public abstract class Animal
{
    public Guid AnimalId { get; set; }
    public string Sound { get; set; }

    public abstract Domain.UseCases.Types.Animal ToDomain();

    public static Animal FromDomain(Domain.UseCases.Types.Animal animal)
    {
        if (animal is null)
        {
            return null;
        }

        return animal.Visit(new AnimalVisitor());
    }

    private class AnimalVisitor : Domain.UseCases.Types.AnimalVisitor<Animal>
    {
        public Animal Visit(Domain.UseCases.Types.Cat cat)
        {
            return new Cat()
            {
                AnimalId = cat.AnimalId,
                Sound = cat.Sound,
                B = cat.B
            };
        }

        public Animal Visit(Domain.UseCases.Types.Cow cow)
        {
            return new Cow()
            {
                AnimalId = cow.AnimalId,
                Sound = cow.Sound,
                C = cow.C
            };
        }

        public Animal Visit(Domain.UseCases.Types.Dog dog)
        {
            return new Dog()
            {
                AnimalId = dog.AnimalId,
                Sound = dog.Sound,
                A = dog.A
            };
        }
    }
}
