package org.example.usecases;

import org.example.types.Animal;

import java.util.UUID;

public interface CreateAnimalUseCase {

    // discrepancy, create-animal.use-case.yml does not reflect the fact that we need effects/ID.
    UUID execute(Animal animal);
}
