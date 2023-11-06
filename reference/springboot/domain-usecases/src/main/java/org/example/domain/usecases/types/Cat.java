package org.example.domain.usecases.types;

import lombok.Builder;
import lombok.Getter;

import java.util.UUID;

@Getter
public class Cat extends Animal {
    private String b;

    @Builder
    public Cat(UUID id, String sound, String b) {
        super(id, sound);
        this.b = b;
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitCat(this);
    }
}
