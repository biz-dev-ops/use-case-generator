package org.example.rest.dto;

import lombok.Data;

import java.net.URI;

@Data
public class CreateAnimalResponse {
    private URI location;
}
