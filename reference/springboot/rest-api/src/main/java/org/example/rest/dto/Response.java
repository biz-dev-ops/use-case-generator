package org.example.rest.dto;

import lombok.Data;

import java.util.List;

@Data
public class Response {
    private List<MessageDto> messages;
}
