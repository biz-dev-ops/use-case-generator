package org.example.domain.usecases;

import org.example.domain.DomainService;
import org.example.domain.commands.GetAnimal;
import lombok.RequiredArgsConstructor;
import org.example.types.Animal;
import org.example.usecases.GetAnimalUseCase;
import org.springframework.stereotype.Service;

import java.util.UUID;

@Service
@RequiredArgsConstructor
public class GetAnimalUseCaseService implements GetAnimalUseCase {
    private final DomainService domainService;

    @Override
    public Animal query(UUID id) {
        return domainService.query(GetAnimal.byId(id));
    }
}
