package org.example.domain.usecases.types;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.util.UUID;

@Getter
@AllArgsConstructor
public abstract class Animal {
    private final UUID animalId;
    private final String sound;

    public abstract <T> T visit(AnimalVisitor<T> visitor);
}
