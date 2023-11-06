using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.Product.Domain.UseCases.Types
{


    public enum AnimalKind
    {
        CAT,
        COW,
        DOG
    }

    public static class AnimalKindHelper
    {
        private static Dictionary<AnimalKind, Type> Types = new Dictionary<AnimalKind, Type>() {
            { AnimalKind.CAT, typeof(Cat) },
            { AnimalKind.COW, typeof(Cow) },
            { AnimalKind.DOG, typeof(Dog) },
        };

        public static AnimalKind FromAnimal(Animal animal)
        {
            if (animal is null)
            {
                throw new ArgumentNullException(nameof(animal));
            }

            return Types
                .First(kvp => kvp.Value.Equals(animal.GetType()))
                .Key;
        }
    }
}