package org.example.adapters.rest;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.example.domain.usecases.GetAnimalUseCase;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.UUID;

@RestController
public class AnimalsController extends AbstractAnimalsApi {

    public AnimalsController(GetAnimalUseCase getAnimalUseCase, GetAnimalsUseCase getAnimalsUseCase, CreateAnimalUseCase createAnimalUseCase) {
        super(getAnimalUseCase, getAnimalsUseCase, createAnimalUseCase);
    }

    @Override
    public ResponseEntity<GetAnimalsResponse> getAnimals(int limit, int offset) {
        var response = super.getAnimals(limit, offset);

        // discrepancy, path duplication. Is there a possibility to construct url bases on an operation?
        var nextLink = UriComponentsBuilder.fromPath("/animals")
            .queryParam("limit", limit)
            .queryParam("offset", offset + limit)
            .build()
            .toUri();

        response.getBody().getLinks().setNext(nextLink);
        return response;
    }

    @Override
    public ResponseEntity<GetAnimalResponse> getAnimal(UUID animal_id) {
        return super.getAnimal(animal_id);
    }

    @Override
    public ResponseEntity<Void> createAnimal(AnimalDto animal) {
        super.createAnimal(animal);
         // discrepancy, path duplication. Is there a possibility to construct url bases on an operation?
        var location = UriComponentsBuilder.fromPath("/animals/{animal_id}").build(animal.getAnimalId());
        return ResponseEntity.created(location).build();
    }
}
