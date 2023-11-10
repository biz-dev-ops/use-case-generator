package org.example.adapters.rest;

import lombok.RequiredArgsConstructor;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
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
    public ResponseEntity<Void> createAnimal(AnimalDto animal) {
        createAnimalUseCase.createAnimal(animal.toDomain());
        return map(animal);
    }

    @Override
    public ResponseEntity<GetAnimalResponse> getAnimal(UUID animalId) {
        var animal = getAnimalUseCase.getAnimal(animalId);
        return map(animalId, AnimalDto.fromDomain(animal));
    }

    @Override
    public ResponseEntity<GetAnimalsResponse> getAnimals(int limit, int offset) {
        //discrepancy, map explicit limit/offset to best-practice Page/Pageable
        var animals = getAnimalsUseCase.getAnimals(limit, offset);

       return map(
            limit, 
            offset, 
            animals.stream()
                .map(AnimalDto::fromDomain)
                .toList()
        );
    }

    protected abstract ResponseEntity<Void> map(AnimalDto animal);
    protected abstract ResponseEntity<GetAnimalResponse> map(UUID animalId, AnimalDto useCaseResponse);
    protected abstract ResponseEntity<GetAnimalsResponse> map(int limit, int offset, List<AnimalDto> useCaseResponse);
}
