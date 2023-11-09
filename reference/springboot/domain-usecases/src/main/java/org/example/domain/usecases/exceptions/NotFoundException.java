package org.example.domain.usecases.exceptions;

public class NotFoundException extends RuntimeException {

    protected NotFoundException() {
        this(null);
    }

    protected NotFoundException(Throwable cause) {
        super("Resource not found.", cause);
    }
    
}
