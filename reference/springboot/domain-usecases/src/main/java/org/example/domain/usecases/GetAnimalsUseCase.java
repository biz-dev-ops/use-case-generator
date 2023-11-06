package org.example.domain.usecases;

import org.example.domain.usecases.types.Animal;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

public interface GetAnimalsUseCase {

    Page<Animal> getAnimals(Pageable pageable);
}
