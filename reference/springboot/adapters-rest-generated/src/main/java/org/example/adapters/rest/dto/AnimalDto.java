package org.example.adapters.rest.dto;

import com.fasterxml.jackson.annotation.*;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.types.AnimalVisitor;
import org.example.domain.usecases.types.Cat;
import org.example.domain.usecases.types.Cow;
import org.example.domain.usecases.types.Dog;

import java.util.UUID;

/*
 discriminator:
    propertyName: object_type
    mapping:
      "CAT": "#/cat"
      "COW": "#/cow"
      "DOG": "#/dog"
 */

@Data
@Schema(name = "Animal")
@JsonIgnoreProperties(
    value = "object_type", 
    allowSetters = true
)
@JsonTypeInfo(
    use = JsonTypeInfo.Id.NAME, 
    property = "object_type", 
    visible = true
)
@JsonSubTypes({
    @JsonSubTypes.Type(value = CatDto.class, name = "CAT"),
    @JsonSubTypes.Type(value = CowDto.class, name = "COW"),
    @JsonSubTypes.Type(value = DogDto.class, name = "DOG"),
})
@JsonTypeName("Animal")
public abstract class AnimalDto {
    @JsonProperty("animal_id")
    private UUID animalId;
    @JsonProperty("sound")
    private String sound;

    public abstract Animal toDomain();

    public static AnimalDto fromDomain(Animal domain) {
        return domain.visit(new AnimalVisitor<>() {
            @Override
            public AnimalDto visit(Dog dog) {
                return DogDto.fromDomain(dog);
            }

            @Override
            public AnimalDto visit(Cat cat) {
                return CatDto.fromDomain(cat);
            }

            @Override
            public AnimalDto visit(Cow cow) {
                return CowDto.fromDomain(cow);
            }
        });
    }
}
