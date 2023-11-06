package org.example.usecases;

import org.example.types.Animal;

import java.util.UUID;

public interface GetAnimalUseCase {

    Animal query(UUID id);
}
