package org.example.adapters.rest;

import lombok.RequiredArgsConstructor;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.adapters.rest.dto.LinksDto;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.example.domain.usecases.GetAnimalUseCase;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.http.ResponseEntity;
import java.util.List;
import java.util.UUID;

@RequiredArgsConstructor
public abstract class AbstractAnimalsApi implements AnimalsApi {
    private final GetAnimalUseCase getAnimalUseCase;
    private final GetAnimalsUseCase getAnimalsUseCase;
    private final CreateAnimalUseCase createAnimalUseCase;

    @Override
    public ResponseEntity<Void> createAnimal(AnimalDto content) {
        createAnimalUseCase.createAnimal(content.toDomain());
        return null;
    }

    @Override
    public ResponseEntity<GetAnimalResponse> getAnimal(UUID animal_id) {
        var animal = getAnimalUseCase.getAnimal(animal_id);
        var response = new GetAnimalResponse();
        response.setAnimal(AnimalDto.fromDomain(animal));
        response.setMessages(List.of()); // why GET response contains .messages?
        return ResponseEntity.ok(response);
    }

    @Override
    public ResponseEntity<GetAnimalsResponse> getAnimals(int limit, int offset) {
        //discrepancy, map explicit limit/offset to best-practice Page/Pageable
        var animals = getAnimalsUseCase.getAnimals(limit, offset);

        var response = new GetAnimalsResponse();
        response.setAnimals(animals.stream()
            .map(AnimalDto::fromDomain)
            .toList());
        response.setLinks(new LinksDto());
        response.setMessages(List.of()); // why?
        return ResponseEntity.ok(response);
    }
}
