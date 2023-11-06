using System;
using System.Collections.Generic;
using Company.Product.Domain.UseCases.Types;

public class AnimalStore
{
    private  List<Animal> animals = new List<Animal>()
    {
        new Dog()
        {
            AnimalId = Guid.Parse("1295c80b-cab3-4f42-ab2d-efbc27128eed"),
            Sound = "woef",
            A = "bd33fdd5-9070-4321-a42a-fa86a7fe64f4"
        },
        new Cow()
        {
            AnimalId = Guid.Parse("bf774232-0af3-4170-b45f-c8a84c0eebfe"),
            Sound = "mooooow",
            C = "f0eee6af-b31f-4ea1-a295-00bf5006f936"
        },
        new Cat()
        {
            AnimalId = Guid.Parse("5754aa13-9041-45bf-8dfb-844a1db38f7b"),
            Sound = "miauw",
            B = "4a2b9889-2ca0-452c-ab42-34d093c0b2b5"
        }
    };
    
    public IEnumerable<Animal> Animals { get { return animals; } }

    public void Add(Animal animal)
    {
        animals.Add(animal);
    }
}