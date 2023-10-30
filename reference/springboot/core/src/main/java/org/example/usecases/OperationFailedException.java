package org.example.usecases;

// downstream failed, 500 service unavailable
public class OperationFailedException extends DomainException {

    protected OperationFailedException(String message) {
        super(message);
    }

    protected OperationFailedException(String message, Throwable cause) {
        super(message, cause);
    }
}
