package org.example.domain.usecases.types;

import lombok.Builder;
import lombok.Getter;

import java.util.UUID;

@Getter
public class Cow extends Animal {
    private String c;

    @Builder
    public Cow(UUID id, String sound, String c) {
        super(id, sound);
        this.c = c;
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitCow(this);
    }
}
