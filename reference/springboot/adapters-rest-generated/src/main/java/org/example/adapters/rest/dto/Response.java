package org.example.adapters.rest.dto;

import lombok.Data;

import java.util.List;

@Data
public class Response {
    private List<MessageDto> messages;
}
