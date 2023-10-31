package org.example.rest.dto;

import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.types.Animal;
import org.example.types.Cat;

@Data
@Schema(name = "Cat")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Cat")
public class CatDto extends AnimalDto {
    private String b;

    @Override
    public Animal toDomain() {
        return new Cat(getAnimalId(), getB());
    }
}
