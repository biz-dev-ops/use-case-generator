package org.example.domain.usecases.exceptions;

public class NotAuthenticatedException extends RuntimeException {

    protected NotAuthenticatedException() {
        this(null);
    }

    protected NotAuthenticatedException(Throwable cause) {
        super("User must be authenticated to execute this use-case.", cause);
    }
    
}
