package org.example.adapters.rest;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.CreateAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

@RestController
@Tag(name = "animals", description = "Animals API")
public interface AnimalsApi {

    @Operation(
        operationId = "GetAnimals",
        summary = "Retrieves animals.",
        tags = "animals",
        responses = {
            @ApiResponse(
                responseCode = "200",
                description = "OK",
                content = @Content(
                    mediaType = "application/json",
                    schema = @Schema(implementation = GetAnimalsResponse.class))),
        }
    )
    @GetMapping(
        value = "/animals",
        produces = MediaType.APPLICATION_JSON_VALUE
    )
    ResponseEntity<GetAnimalsResponse> getAnimals(@RequestParam("limit") int limit,
                                                  @RequestParam("offset") int offset);

    @Operation(
        operationId = "GetAnimal",
        summary = "Retrieves an animal.",
        tags = "animals",
        responses = {
            @ApiResponse(
                responseCode = "200",
                description = "OK",
                content = @Content(
                    mediaType = "application/json",
                    schema = @Schema(implementation = GetAnimalsResponse.class))),
        }
    )
    @GetMapping(
        value = "/animals/{animal_id}",
        produces = MediaType.APPLICATION_JSON_VALUE
    )
    ResponseEntity<GetAnimalResponse> getAnimal(@PathVariable("animal_id") UUID animal_id);

    @Operation(
        operationId = "CreateAnimal",
        summary = "Create animal.",
        tags = "animals",
        responses = {
            @ApiResponse(
                responseCode = "201",
                description = "Created at",
                content = @Content(
                    mediaType = "application/json",
                    schema = @Schema(implementation = CreateAnimalResponse.class))),
        }
    )
    @PostMapping(
        value = "/animals",
        consumes = MediaType.APPLICATION_JSON_VALUE,
        produces = MediaType.APPLICATION_JSON_VALUE
    )
    ResponseEntity<CreateAnimalResponse> createAnimal(@RequestBody AnimalDto content);
}
