package org.example.adapters.rest;

import org.example.adapters.rest.dto.AnimalDto;
import org.example.adapters.rest.dto.CatDto;
import org.example.adapters.rest.dto.CowDto;
import org.example.adapters.rest.dto.DogDto;
import org.example.domain.usecases.types.*;
import org.springframework.data.domain.Page;

import java.util.List;

public class DomainDtoMapper {

    public static AnimalDto map(Animal domain) {
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
            }
        });
    }

    public static List<AnimalDto> map(Page<Animal> animals) {
        return animals.map(DomainDtoMapper::map)
            .toList();
    }

    public static Animal map(AnimalDto dto) {
        return dto.toDomain();
    }
}
