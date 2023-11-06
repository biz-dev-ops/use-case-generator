package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class CreateAnimalUseCaseService implements CreateAnimalUseCase {
    
    @Override
    public void createAnimal(Animal animal) {
        throw new java.lang.UnsupportedOperationException("");
    }
}
