package org.example.domain.usecases.types;

import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Getter;

import java.util.UUID;

@Getter
@AllArgsConstructor(access = AccessLevel.PROTECTED)
public abstract class Animal {
    private UUID animalId;
    private String sound;

    public abstract <T> T visit(AnimalVisitor<T> visitor);
}
