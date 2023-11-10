package org.example.adapters.rest.dto;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.types.Dog;

@Data
@Schema(name = "Dog")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Dog")
public class DogDto extends AnimalDto {
    @JsonProperty("a")
    private String a;

    @Override
    public Animal toDomain() {
        return new Dog(getAnimalId(), getSound(), getA());
    }

    public static DogDto fromDomain(Dog dog) {
        var dto = new DogDto();
        dto.setAnimalId(dog.getAnimalId());
        dto.setSound((dog.getSound()));
        dto.setA(dog.getA());
        return dto;
    }
}
