namespace Company.Product.Adapters.Rest.Models;

public class AnimalMapper : Domain.UseCases.Types.AnimalVisitor<Animal>
{
    public static Animal FromDomain(Domain.UseCases.Types.Animal animal)
    {
        return animal.Visit(new AnimalMapper());
    }

    public static Domain.UseCases.Types.Animal ToDomain(Animal animal)
    {
        return animal.ToDomain();
    }

    public Animal VisitCat(Domain.UseCases.Types.Cat cat)
    {
        return new Cat()
        {
            AnimalId = cat.AnimalId,
            Sound = cat.Sound,
            B = cat.B
        };
    }

    public Animal VisitCow(Domain.UseCases.Types.Cow cow)
    {
        return new Cow()
        {
            AnimalId = cow.AnimalId,
            Sound = cow.Sound,
            C = cow.C
        };
    }

    public Animal VisitDog(Domain.UseCases.Types.Dog dog)
    {
        return new Dog()
        {
            AnimalId = dog.AnimalId,
            Sound = dog.Sound,
            A = dog.A
        };
    }
}
