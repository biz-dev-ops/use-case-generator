using System;

namespace Company.Product.Domain.UseCases.Types
{
    public class Cow : Animal
    {
        public string C { get; }

        public Cow(Guid animalId, string sound, string c) 
            : base(animalId, sound)
        {
            C = c;
        }

        public override T Visit<T>(AnimalVisitor<T> visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            return visitor.Visit(this);
        }
    }
}