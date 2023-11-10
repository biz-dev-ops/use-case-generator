package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;
import org.example.domain.usecases.types.Animal;
import org.springframework.stereotype.Service;

import java.util.UUID;
import java.util.stream.Stream;

@Service
@RequiredArgsConstructor
public class GetAnimalUseCaseMockService implements GetAnimalUseCase {
    private final AnimalStore animalStore;

    @Override
    public Animal getAnimal(UUID id) {
        return Stream.of(animalStore.getAnimals())
                .filter((a) -> a.getAnimalId().equals(id))
                .findFirst()
                .orElseThrow();
    }
}
