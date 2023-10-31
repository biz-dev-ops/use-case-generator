package org.example.domain.commands;

import org.example.domain.AnimalsDataAccessPort;
import org.example.types.Animal;
import org.example.usecases.NotFoundException;
import org.springframework.data.domain.Pageable;

import java.util.UUID;

public interface GetAnimal<T> {

    static GetAnimal<Animal> byId(UUID id) {
        return dao -> dao.getById(id).orElseThrow(() -> NotFoundException.byId(id));
    }

    static <T extends Animal> GetAnimal<T> byId(UUID id, Class<T> clazz) {
        return dao -> clazz.cast(dao.getById(id).orElseThrow(() -> NotFoundException.byId(id)));
    }

    static GetAnimals<Animal> all() {
        return all(Pageable.unpaged());
    }

    static GetAnimals<Animal> all(Pageable page) {
        return new GetAnimals<>(Animal.class, page);
    }

    T execute(AnimalsDataAccessPort dao);
}
