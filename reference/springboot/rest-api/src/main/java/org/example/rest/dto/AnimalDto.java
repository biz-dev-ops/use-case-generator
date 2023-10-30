package org.example.rest.dto;

import com.fasterxml.jackson.annotation.*;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;
import org.example.types.Animal;

import java.util.UUID;

@Data
@Schema(name = "Animal")
@JsonIgnoreProperties(value = "object_type", allowSetters = true)
@JsonTypeInfo(use = JsonTypeInfo.Id.NAME, property = "object_type", visible = true)
@JsonSubTypes({
    @JsonSubTypes.Type(value = CatDto.class, name = "cat"),
    @JsonSubTypes.Type(value = CowDto.class, name = "cow"),
    @JsonSubTypes.Type(value = DogDto.class, name = "dog"),
})
@JsonTypeName("Animal")
public abstract class AnimalDto {
    @JsonProperty("animal_id")
    private UUID animalId;

    public abstract Animal toDomain();
}
