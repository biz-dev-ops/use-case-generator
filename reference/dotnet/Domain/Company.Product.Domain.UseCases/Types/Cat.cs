using System;

namespace Company.Product.Domain.UseCases.Types
{
    public class Cat : Animal
    {
        public string B { get; }
     
        public Cat(Guid animalId, string sound, string b) 
            : base(animalId, sound)
        {
            B = b;
        }

        public override T Visit<T>(AnimalVisitor<T> visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            return visitor.VisitCat(this);
        }
    }
}