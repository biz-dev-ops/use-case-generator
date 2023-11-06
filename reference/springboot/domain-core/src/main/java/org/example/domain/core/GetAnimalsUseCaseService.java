package org.example.domain.usecases;

import lombok.RequiredArgsConstructor;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class GetAnimalsUseCaseService implements GetAnimalsUseCase {
    
    @Override
    public Page<Animal> getAnimals(Pageable pageable) {
        throw new java.lang.UnsupportedOperationException("");
    }
}
