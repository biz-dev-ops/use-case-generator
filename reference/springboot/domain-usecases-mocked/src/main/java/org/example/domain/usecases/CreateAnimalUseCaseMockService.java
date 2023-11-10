package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;
import org.example.domain.usecases.types.Animal;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class CreateAnimalUseCaseMockService implements CreateAnimalUseCase {
    private final AnimalStore animalStore;

    @Override
    public void createAnimal(Animal animal) {
        animalStore.addAnimal(animal);
    }
}
