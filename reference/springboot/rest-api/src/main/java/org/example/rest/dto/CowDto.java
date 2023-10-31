package org.example.rest.dto;

import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.types.Animal;
import org.example.types.Cow;

@Data
@Schema(name = "Cow")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Cow")
public class CowDto extends AnimalDto {
    private String c;

    @Override
    public Animal toDomain() {
        return new Cow(getAnimalId(), getC());
    }
}
