package org.example.types;

import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.util.UUID;

@Getter
@Setter
@AllArgsConstructor(access = AccessLevel.PROTECTED)
public abstract class Animal {
    private UUID animalId;
    private Kind objectType;

    public abstract <T> T visit(AnimalVisitor<T> visitor);

    public abstract Animal cloneWithId(UUID id);
}
