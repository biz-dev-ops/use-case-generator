using System;

namespace Company.Product.Domain.UseCases.Types
{
    public class Dog : Animal
    {
        public string A { get;}

        public Dog(Guid animalId, string sound, string a) : base(animalId, sound)
        {
            A = a;
        }

        public override T Visit<T>(AnimalVisitor<T> visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            return visitor.VisitDog(this);
        }
    }
}