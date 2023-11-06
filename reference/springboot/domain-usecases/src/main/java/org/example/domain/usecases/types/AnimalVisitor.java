package org.example.domain.usecases.types;

/*
  oneOf:
    - $ref: "#/dog"
    - $ref: "#/cat"
    - $ref: "#/cow"
 */
public interface AnimalVisitor<T> {

    T visitDog(Dog dog);

    T visitCat(Cat cat);

    T visitCow(Cow cow);
}
