package org.example.rest;

import lombok.RequiredArgsConstructor;
import org.example.rest.dto.AnimalDto;
import org.example.rest.dto.CreateAnimalResponse;
import org.example.rest.dto.GetAnimalResponse;
import org.example.rest.dto.GetAnimalsResponse;
import org.example.usecases.CreateAnimalUseCase;
import org.example.usecases.GetAnimalUseCase;
import org.example.usecases.GetAnimalsUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.UUID;

import static org.example.rest.ResponseMapper.*;

@RestController
@RequiredArgsConstructor
public class AnimalsController implements AnimalsApi {
    private final GetAnimalUseCase getAnimalUseCase;
    private final GetAnimalsUseCase getAnimalsUseCase;
    private final CreateAnimalUseCase createAnimalUseCase;

    @Override
    public ResponseEntity<GetAnimalsResponse> getAnimals(int limit, int offset) {
        // discrepancy, map explicit limit/offset to best-practice Page/Pageable
        var response = mapGetAnimalsResponse(getAnimalsUseCase.query(limitOffsetToPageable(limit, offset)));
        return ResponseEntity.ok(response);
    }

    @Override
    public ResponseEntity<GetAnimalResponse> getAnimal(UUID animal_id) {
        var response = mapGetAnimalResponse(getAnimalUseCase.query(animal_id));
        return ResponseEntity.ok(response);
    }

    @Override
    public ResponseEntity<CreateAnimalResponse> createAnimal(AnimalDto content) {
        var id = createAnimalUseCase.execute(DomainDtoMapper.map(content));
        var location = UriComponentsBuilder.fromPath("/animals/{animal_id}").build(id);
        var response = mapCreateAnimalResponse(id, location);
        return ResponseEntity.created(location).body(response);
    }
}
