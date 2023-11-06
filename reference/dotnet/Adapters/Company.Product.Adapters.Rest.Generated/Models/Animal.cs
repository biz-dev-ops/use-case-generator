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
}
