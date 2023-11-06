package org.example.domain.usecases;

import org.example.domain.usecases.types.Animal;

public interface CreateAnimalUseCase {

    // discrepancy, create-animal.use-case.yml does not reflect the fact that we need effects/ID.
    void createAnimal(Animal animal);
}
