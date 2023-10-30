package org.example.types;

import lombok.Getter;
import lombok.Setter;

import java.util.UUID;

@Getter
@Setter
public class Dog extends Animal {
    private String a;

    public Dog(UUID id, String a) {
        super(id, Kind.DOG);
        this.a = a;
    }

    public Dog(String a) {
        this(null, a);
    }

    @Override
    public <T> T visit(AnimalVisitor<T> visitor) {
        return visitor.visitDog(this);
    }

    @Override
    public Dog cloneWithId(UUID id) {
        return new Dog(id, getA());
    }
}
