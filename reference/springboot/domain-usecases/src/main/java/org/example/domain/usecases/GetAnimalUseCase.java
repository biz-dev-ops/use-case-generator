package org.example.domain.usecases;

import org.example.domain.usecases.types.Animal;

import java.util.UUID;

public interface GetAnimalUseCase {

    Animal getAnimal(UUID id);
}
