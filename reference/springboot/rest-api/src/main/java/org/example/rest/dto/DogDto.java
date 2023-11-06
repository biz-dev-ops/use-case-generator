package org.example.rest.dto;

import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.types.Animal;
import org.example.types.Dog;

@Data
@Schema(name = "Dog")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Dog")
public class DogDto extends AnimalDto {
    private String a;

    @Override
    public Animal toDomain() {
        return new Dog(getAnimalId(), getA());
    }
}
