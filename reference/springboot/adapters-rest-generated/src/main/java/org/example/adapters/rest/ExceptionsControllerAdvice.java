package org.example.adapters.rest;

import org.example.adapters.rest.dto.MessageDto;
import org.example.adapters.rest.dto.Response;
// import org.example.domain.usecases.DomainException;
// import org.example.domain.usecases.NotFoundException;
// import org.example.domain.usecases.OperationFailedException;
// import org.example.domain.usecases.PreconditionFailedException;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestControllerAdvice;

import java.util.List;

@RestControllerAdvice
public class ExceptionsControllerAdvice {

    // @ExceptionHandler
    // @ResponseStatus(HttpStatus.NOT_FOUND)
    // public Response handleNotFoundException(NotFoundException exception) {
    //     return toMessage(exception);
    // }

    // @ExceptionHandler
    // @ResponseStatus(HttpStatus.BAD_REQUEST)
    // public Response handlePreconditionFailedException(PreconditionFailedException exception) {
    //     return toMessage(exception);
    // }

    // @ExceptionHandler
    // @ResponseStatus(HttpStatus.SERVICE_UNAVAILABLE)
    // public Response handleOperationFailedException(OperationFailedException exception) {
    //     return toMessage(exception);
    // }

    // private Response toMessage(DomainException exception) {
    //     var dto = new MessageDto();
    //     dto.setType(MessageDto.TypeValues.ERROR);
    //     dto.setMessage(exception.getMessage());

    //     var response = new Response();
    //     response.setMessages(List.of(dto));
    //     return response;
    // }
}
