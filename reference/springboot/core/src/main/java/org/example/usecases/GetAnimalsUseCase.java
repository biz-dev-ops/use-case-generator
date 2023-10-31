package org.example.usecases;

import org.example.types.Animal;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

public interface GetAnimalsUseCase {

    Page<Animal> query(Pageable pageable);
}
