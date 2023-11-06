package org.example.usecases;

import java.util.UUID;

// 404 not found
public class NotFoundException extends DomainException {

    public NotFoundException(String message) {
        super(message);
    }

    public static NotFoundException byId(UUID id) {
        return new NotFoundException("Animal with ID %s is not found".formatted(id));
    }
}
