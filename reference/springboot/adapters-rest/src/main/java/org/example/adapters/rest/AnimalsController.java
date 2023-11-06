package org.example.adapters.rest;

import lombok.RequiredArgsConstructor;
import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.CreateAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.domain.usecases.CreateAnimalUseCase;
import org.example.domain.usecases.GetAnimalUseCase;
import org.example.domain.usecases.GetAnimalsUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.UUID;

import static org.example.adapters.rest.ResponseMapper.*;

@RestController
@RequiredArgsConstructor
public class AnimalsController implements AnimalsApi {
    private final GetAnimalUseCase getAnimalUseCase;
    private final GetAnimalsUseCase getAnimalsUseCase;
    private final CreateAnimalUseCase createAnimalUseCase;

    @Override
    public ResponseEntity<GetAnimalsResponse> getAnimals(int limit, int offset) {
        // discrepancy, map explicit limit/offset to best-practice Page/Pageable
        var response = mapGetAnimalsResponse(getAnimalsUseCase.getAnimals(limitOffsetToPageable(limit, offset)));
        return ResponseEntity.ok(response);
    }

    @Override
    public ResponseEntity<GetAnimalResponse> getAnimal(UUID animal_id) {
        var response = mapGetAnimalResponse(getAnimalUseCase.getAnimal(animal_id));
        return ResponseEntity.ok(response);
    }

    @Override
    public ResponseEntity<CreateAnimalResponse> createAnimal(AnimalDto animal) {
        createAnimalUseCase.createAnimal(DomainDtoMapper.map(animal));
        var location = UriComponentsBuilder.fromPath("/animals/{animal_id}").build(animal.getAnimalId());
        var response = mapCreateAnimalResponse(location);
        return ResponseEntity.created(location).body(response);
    }
}
