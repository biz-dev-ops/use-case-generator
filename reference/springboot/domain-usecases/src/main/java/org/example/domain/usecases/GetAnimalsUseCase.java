package org.example.domain.usecases;

import java.util.List;

import org.example.domain.usecases.types.Animal;

public interface GetAnimalsUseCase {

    List<Animal> getAnimals(int limit, int offset);
}
