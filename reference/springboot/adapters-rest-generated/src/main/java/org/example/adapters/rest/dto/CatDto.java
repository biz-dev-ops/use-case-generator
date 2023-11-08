package org.example.adapters.rest.dto;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonTypeName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.example.domain.usecases.types.Animal;
import org.example.domain.usecases.types.Cat;

@Data
@Schema(name = "Cat")
@EqualsAndHashCode(callSuper = true)
@JsonTypeName("Cat")
public class CatDto extends AnimalDto {
    @JsonProperty("b")
    private String b;

    @Override
    public Animal toDomain() {
        return new Cat(getAnimalId(), getSound(), getB());
    }

    public static CatDto fromDomain(Cat cat) {
        var dto = new CatDto();
        dto.setAnimalId(cat.getAnimalId());
        dto.setSound((cat.getSound()));
        dto.setB(cat.getB());
        return dto;
    }
}
