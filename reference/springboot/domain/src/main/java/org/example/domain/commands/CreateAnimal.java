package org.example.domain.commands;

import org.example.domain.AnimalsDataAccessPort;
import org.example.types.Animal;

import java.util.UUID;

public interface CreateAnimal<T> {

    static CreateAnimal<UUID> andReturnId(Animal newAnimal) {
        return dao -> dao.createNewAnimalAndReturnId(newAnimal);
    }

    static CreateAnimal<Animal> andReturnModel(Animal newAnimal) {
        return dao -> newAnimal.cloneWithId(dao.createNewAnimalAndReturnId(newAnimal));
    }

    T execute(AnimalsDataAccessPort dao);
}
