package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.GetAnimalUseCase;
import org.springframework.stereotype.Service;

import java.util.UUID;

@Service
@RequiredArgsConstructor
public class GetAnimalUseCaseService implements GetAnimalUseCase {
    
    @Override
    public Animal getAnimal(UUID id) {
        throw new java.lang.UnsupportedOperationException("");
    }
}
