package org.example.usecases;

// validation failed, bad request
public class PreconditionFailedException extends DomainException {

    protected PreconditionFailedException(String message) {
        super(message);
    }

    protected PreconditionFailedException(String message, Throwable cause) {
        super(message, cause);
    }
}
