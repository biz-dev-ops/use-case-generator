package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;

import java.util.List;
import java.util.stream.Stream;

import org.example.domain.usecases.types.Animal;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class GetAnimalsUseCaseMockService implements GetAnimalsUseCase {
    private final AnimalStore animalStore;
    
    @Override
    public List<Animal> getAnimals(int limit, int offset) {
        return Stream.of(animalStore.getAnimals())
            .skip(offset)
            .limit(limit)
            .toList();
    }
}
