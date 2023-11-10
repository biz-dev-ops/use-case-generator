package org.example.domain.usecases.types;

/*
  oneOf:
    - $ref: "#/dog"
    - $ref: "#/cat"
    - $ref: "#/cow"
 */
public interface AnimalVisitor<T> {

    T visit(Dog dog);

    T visit(Cat cat);

    T visit(Cow cow);
}
