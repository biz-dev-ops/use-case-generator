using System.Text.Json.Serialization;

namespace Company.Product.Domain.UseCases.Types
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "object_type")]
    [JsonDerivedType(typeof(Cat), typeDiscriminator: "CAT")]
    [JsonDerivedType(typeof(Cow), typeDiscriminator: "COW")]
    [JsonDerivedType(typeof(Dog), typeDiscriminator: "DOG")]
    public interface Animal
    { }
}