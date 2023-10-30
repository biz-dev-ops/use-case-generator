package org.example.memory;

import org.springframework.boot.autoconfigure.AutoConfiguration;
import org.springframework.boot.autoconfigure.condition.ConditionalOnProperty;
import org.springframework.context.annotation.Import;

@AutoConfiguration
@ConditionalOnProperty(prefix = "application", name = "storage", havingValue = "in-memory", matchIfMissing = true)
@Import(InMemoryAnimalsDataAccessService.class)
public class InMemoryAutoConfiguration {
}
