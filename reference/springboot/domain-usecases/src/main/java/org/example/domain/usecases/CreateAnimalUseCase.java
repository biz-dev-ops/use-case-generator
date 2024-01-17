package org.example.domain.usecases;

import org.example.domain.usecases.exceptions.NotAuthenticatedException;
import org.example.domain.usecases.exceptions.NotAuthorizedException;
import org.example.domain.usecases.types.Animal;

public interface CreateAnimalUseCase {

    void createAnimal(Animal animal) throws NotAuthenticatedException, NotAuthorizedException;
}
