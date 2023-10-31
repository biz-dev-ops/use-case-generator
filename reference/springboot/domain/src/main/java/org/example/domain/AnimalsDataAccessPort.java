package org.example.domain;

import org.example.types.Animal;
import org.example.types.Kind;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.Optional;
import java.util.UUID;

public interface AnimalsDataAccessPort {

    Optional<Animal> getById(UUID id);

    Page<Animal> findByKind(Optional<Kind> kind, Pageable pageable);

    UUID createNewAnimalAndReturnId(Animal animal);

    boolean deleteById(UUID id);

    int deleteByKind(Optional<Kind> kind);
}
