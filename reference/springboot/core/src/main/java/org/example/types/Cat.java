package org.example.types;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

import java.util.UUID;

@Getter
@Setter
public class Cat extends Animal {
    private String b;

    @Builder
    public Cat(UUID id, String b) {
        super(id, Kind.CAT);
        this.b = b;
    }

    public Cat(String b) {
        this(null, b);
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitCat(this);
    }

    @Override
    public Cat cloneWithId(UUID id) {
        return new Cat(id, getB());
    }
}
