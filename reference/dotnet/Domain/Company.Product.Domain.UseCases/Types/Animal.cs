using System;

namespace Company.Product.Domain.UseCases.Types
{

    public abstract class Animal
    {
        public Guid AnimalId { get; }

        public string Sound { get; }

        protected Animal(Guid animalId, string sound)
        {
            AnimalId = animalId;
            Sound = sound;
        }

        public abstract T Visit<T>(AnimalVisitor<T> visitor);
    }
}