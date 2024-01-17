package org.example.domain.usecases;

import org.example.domain.usecases.exceptions.NotAuthenticatedException;
import org.example.domain.usecases.exceptions.NotAuthorizedException;
import org.example.domain.usecases.exceptions.NotFoundException;
import org.example.domain.usecases.types.Animal;

import java.util.UUID;

public interface GetAnimalUseCase {

    Animal getAnimal(UUID id) throws NotAuthenticatedException, NotAuthorizedException, NotFoundException;
}
