package org.example.domain.usecases;

import org.example.domain.DomainService;
import org.example.domain.commands.CreateAnimal;
import lombok.RequiredArgsConstructor;
import org.example.types.Animal;
import org.example.usecases.CreateAnimalUseCase;
import org.springframework.stereotype.Service;

import java.util.UUID;

@Service
@RequiredArgsConstructor
public class CreateAnimalUseCaseService implements CreateAnimalUseCase {
    private final DomainService domainService;

    @Override
    public UUID execute(Animal animal) {
        return domainService.execute(CreateAnimal.andReturnId(animal));
    }
}
