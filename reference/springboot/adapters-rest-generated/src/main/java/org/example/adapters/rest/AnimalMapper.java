package org.example.adapters.rest;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.CatDto;
import org.example.adapters.rest.dto.CowDto;
import org.example.adapters.rest.dto.DogDto;
import org.example.domain.usecases.types.*;

public class AnimalMapper {

    public static AnimalDto fromDomain(Animal domain) {
        return domain.visit(new AnimalVisitor<>() {

            @Override
            public AnimalDto visitDog(Dog dog) {
                var dto = new DogDto();
                dto.setA(dog.getA());
                setAnimal(dto, dog);
                return dto;
            }

            @Override
            public AnimalDto visitCat(Cat cat) {
                var dto = new CatDto();
                dto.setB(cat.getB());
                setAnimal(dto, cat);
                return dto;
            }

            @Override
            public AnimalDto visitCow(Cow cow) {
                var dto = new CowDto();
                dto.setC(cow.getC());
                setAnimal(dto, cow);
                return dto;
            }

            private void setAnimal(AnimalDto dto, Animal animal) {
                dto.setAnimalId(animal.getAnimalId());
                dto.setSound(animal.getSound());
            }
        });
    }

    public static Animal toDomain(AnimalDto dto) {
        return dto.toDomain();
    }
}
