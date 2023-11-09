package org.example.adapters.rest;

import org.example.domain.usecases.exceptions.NotAuthenticatedException;
import org.example.domain.usecases.exceptions.NotAuthorizedException;
import org.example.domain.usecases.exceptions.NotFoundException;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestControllerAdvice;

//TODO: add problem object
@RestControllerAdvice
public class ExceptionsControllerAdvice {
    
    @ExceptionHandler
    @ResponseStatus(HttpStatus.NOT_FOUND)
    public String handleNotFoundException(NotFoundException exception) {
        return exception.getMessage();
    }

    @ExceptionHandler
    @ResponseStatus(HttpStatus.UNAUTHORIZED)
    public String handlePreconditionFailedException(NotAuthenticatedException exception) {
        return exception.getMessage();
    }

    @ExceptionHandler
    @ResponseStatus(HttpStatus.FORBIDDEN)
    public String handleOperationFailedException(NotAuthorizedException exception) {
        return exception.getMessage();
    }
}