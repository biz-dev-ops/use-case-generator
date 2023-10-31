package org.example.rest.dto;

import lombok.Data;
import lombok.EqualsAndHashCode;

@Data
@EqualsAndHashCode(callSuper = true)
public class OffsetResponse extends Response {
    private LinksDto links;
}
