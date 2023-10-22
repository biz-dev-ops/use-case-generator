using BizDevOps.Core.Attributes;

namespace Company.Product.Domain.UseCases.Types
{

    [PolymorphismInfo(DiscriminatorProperty = "object_type")]
    [SubType(typeof(Cat), Discriminator = "CAT")]
    [SubType(typeof(Cow), Discriminator = "COW")]
    [SubType(typeof(Dog), Discriminator = "DOG")]
    public abstract class Animal
    {
        public string Sound { get; set; }
    }
}