package org.example.domain.usecases;

import org.example.domain.DomainService;
import org.example.domain.commands.GetAnimal;
import lombok.RequiredArgsConstructor;
import org.example.types.Animal;
import org.example.usecases.GetAnimalsUseCase;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class GetAnimalsUseCaseService implements GetAnimalsUseCase {
    private final DomainService domainService;

    @Override
    public Page<Animal> query(Pageable pageable) {
        return domainService.query(GetAnimal.all(pageable));
    }
}
