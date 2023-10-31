package org.example.types;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

import java.util.UUID;

@Getter
@Setter
public class Cow extends Animal {
    private String c;

    @Builder
    public Cow(UUID id, String c) {
        super(id, Kind.COW);
        this.c = c;
    }

    public Cow(String c) {
        this(null, c);
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitCow(this);
    }

    @Override
    public Cow cloneWithId(UUID id) {
        return new Cow(id, getC());
    }
}
