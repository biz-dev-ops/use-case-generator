using System;

namespace Company.Product.Domain.UseCases.Types
{
    public class AnimalDoesNotExistException : Exception
    {
        public Guid AnimalId { get; private set; }

        public AnimalDoesNotExistException(Guid animalId) 
            : base($"Animal with id ${animalId} does not exist.")
        {
            AnimalId = animalId;
        }
    }
}