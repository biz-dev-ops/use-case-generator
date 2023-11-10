package org.example.adapters.rest.dto;

import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;

@Data
@Schema(name = "Message")
public class MessageDto {
    private TypeValues type;
    private String message;

    public enum TypeValues {
        ERROR,
        WARN,
        INFO
    }
}
