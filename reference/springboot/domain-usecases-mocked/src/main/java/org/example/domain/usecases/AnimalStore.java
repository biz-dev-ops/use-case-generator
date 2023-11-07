package org.example.domain.usecases;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.types.Cat;
import org.example.domain.usecases.types.Cow;
import org.example.domain.usecases.types.Dog;
import org.springframework.stereotype.Component;

@Component
public class AnimalStore {

    private final List<Animal> animals = new ArrayList<Animal>()
    {{
        add(new Dog(UUID.fromString("1295c80b-cab3-4f42-ab2d-efbc27128eed"), "woef", "bd33fdd5-9070-4321-a42a-fa86a7fe64f4"));
        add(new Cow(UUID.fromString("bf774232-0af3-4170-b45f-c8a84c0eebfe"), "mooooow", "f0eee6af-b31f-4ea1-a295-00bf5006f936"));
        add(new Cat(UUID.fromString("5754aa13-9041-45bf-8dfb-844a1db38f7b"), "miauw", "4a2b9889-2ca0-452c-ab42-34d093c0b2b5"));
    }};

    public Animal[] getAnimals() {
        return animals.toArray(new Animal[animals.size()]);
    }

    public void addAnimal(Animal animal) {
        animals.add(animal);
    }
}
