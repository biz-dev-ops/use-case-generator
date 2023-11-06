package org.example.domain.usecases.types;

import lombok.Builder;
import lombok.Getter;

import java.util.UUID;

@Getter
public class Dog extends Animal {
    private String a;

    @Builder
    public Dog(UUID id, String sound, String a) {
        super(id, sound);
        this.a = a;
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitDog(this);
    }
}
