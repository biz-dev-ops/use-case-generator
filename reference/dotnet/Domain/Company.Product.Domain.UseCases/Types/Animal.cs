using BizDevOps.Core.Attributes;

namespace Company.Product.Domain.UseCases.Types
{

    [PolymorphismInfo("object_type") ]
    [SubType(typeof(Cat), "CAT")]
    [SubType(typeof(Cow), "COW")]
    [SubType(typeof(Dog), "DOG")]
    public abstract class Animal
    {
        public string Sound { get; set; }
    }
}