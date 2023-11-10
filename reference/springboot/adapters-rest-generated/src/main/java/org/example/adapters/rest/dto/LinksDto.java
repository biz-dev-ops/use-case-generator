package org.example.adapters.rest.dto;

import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;

import java.net.URI;

@Data
@Schema(name = "Links")
public class LinksDto {
    private URI next;
}
