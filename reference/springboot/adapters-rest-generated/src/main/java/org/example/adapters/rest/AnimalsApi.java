package org.example.adapters.rest;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.tags.Tag;
import lombok.RequiredArgsConstructor;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.CreateAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.adapters.rest.dto.LinksDto;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.example.domain.usecases.GetAnimalUseCase;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.UUID;

@RestController
@Tag(name = "animals", description = "Animals API")
@RequiredArgsConstructor
public abstract class AnimalsApi {
    private final GetAnimalUseCase getAnimalUseCase;
    private final GetAnimalsUseCase getAnimalsUseCase;
    private final CreateAnimalUseCase createAnimalUseCase;

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
    public ResponseEntity<GetAnimalsResponse> getAnimals(@RequestParam("limit") int limit, @RequestParam("offset") int offset) {
        // discrepancy, map explicit limit/offset to best-practice Page/Pageable
        var animals = getAnimalsUseCase.getAnimals(limit, offset);

        var response = new GetAnimalsResponse();
        response.setAnimals(animals.stream()
            .map(AnimalDto::fromDomain)
            .toList());
        response.setLinks(new LinksDto());
        response.setMessages(List.of()); // why?
        return ResponseEntity.ok(response);
    }

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
    public ResponseEntity<GetAnimalResponse> getAnimal(@PathVariable("animal_id") UUID animal_id) {
        var animal = getAnimalUseCase.getAnimal(animal_id);
        var response = new GetAnimalResponse();
        response.setAnimal(AnimalDto.fromDomain(animal));
        response.setMessages(List.of()); // why GET response contains .messages?
        return ResponseEntity.ok(response);
    }

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
    public ResponseEntity<Void> createAnimal(@RequestBody AnimalDto content) {
        createAnimalUseCase.createAnimal(content.toDomain());
        return null;
    }
}
