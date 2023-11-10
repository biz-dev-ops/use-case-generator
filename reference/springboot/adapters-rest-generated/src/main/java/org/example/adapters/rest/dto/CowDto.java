package org.example.adapters.rest.dto;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.types.Cow;

@Data
@Schema(name = "Cow")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Cow")
public class CowDto extends AnimalDto {
    @JsonProperty("c")
    private String c;

    @Override
    public Animal toDomain() {
        return new Cow(getAnimalId(), getSound(), getC());
    }

    public static CowDto fromDomain(Cow cow) {
        var dto = new CowDto();
        dto.setAnimalId(cow.getAnimalId());
        dto.setSound((cow.getSound()));
        dto.setC(cow.getC());
        return dto;
    }
}
