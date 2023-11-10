package org.example.adapters.rest.dto;

import lombok.Data;
import lombok.EqualsAndHashCode;

import java.util.List;

@Data
@EqualsAndHashCode(callSuper = true)
public class GetAnimalsResponse extends OffsetResponse {
    private List<AnimalDto> animals;
}
