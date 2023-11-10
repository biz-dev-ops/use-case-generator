package org.example.adapters.rest;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.adapters.rest.dto.LinksDto;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.example.domain.usecases.GetAnimalUseCase;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.List;
import java.util.UUID;

@RestController
public class AnimalsController extends AbstractAnimalsApi {

    public AnimalsController(GetAnimalUseCase getAnimalUseCase, GetAnimalsUseCase getAnimalsUseCase, CreateAnimalUseCase createAnimalUseCase) {
        super(getAnimalUseCase, getAnimalsUseCase, createAnimalUseCase);
    }

    @Override
    protected ResponseEntity<Void> map(AnimalDto animal) {
        var location = UriComponentsBuilder.fromPath("/animals/{animal_id}").build(animal.getAnimalId());
        return ResponseEntity.created(location).build();
    }

    @Override
    protected ResponseEntity<GetAnimalResponse> map(UUID animalId, AnimalDto useCaseResponse) {
        if(useCaseResponse == null) {
            return ResponseEntity.notFound().build();
        }

        var response = new GetAnimalResponse();
        response.setAnimal(useCaseResponse);
        response.setMessages(List.of()); // why GET response contains .messages?
        return ResponseEntity.ok(response);
    }

    @Override
    protected ResponseEntity<GetAnimalsResponse> map(int limit, int offset, List<AnimalDto> useCaseResponse) {
        var next = UriComponentsBuilder.fromPath("/animals")
            .queryParam("limit", limit)
            .queryParam("offset", offset + limit)
            .build()
            .toUri();

        var links = new LinksDto();
        links.setNext( next);

        var response = new GetAnimalsResponse();
        response.setAnimals(useCaseResponse);
        response.setLinks(links);
        response.setMessages(List.of()); // why?
        return ResponseEntity.ok(response);
    }
}
