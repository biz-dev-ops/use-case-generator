package org.example.domain.usecases.exceptions;

public class NotAuthorizedException extends RuntimeException {

    protected NotAuthorizedException() {
        this(null);
    }

    protected NotAuthorizedException(Throwable cause) {
        super("User is not authorized to execute this use-case.", cause);
    }
    
}
