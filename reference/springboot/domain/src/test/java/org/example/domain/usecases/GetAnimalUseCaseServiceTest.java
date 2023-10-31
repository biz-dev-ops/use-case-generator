package org.example.domain.usecases;

import org.example.domain.AnimalsDataAccessPort;
import org.example.domain.DomainService;
import org.example.types.Cat;
import org.example.usecases.NotFoundException;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Optional;
import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class GetAnimalUseCaseServiceTest {
    private static final UUID ID = UUID.randomUUID();
    private AnimalsDataAccessPort port;
    private GetAnimalUseCaseService getAnimalUseCaseService;

    @BeforeEach
    void setUp() {
        port = mock(AnimalsDataAccessPort.class);
        when(port.getById(any(UUID.class))).thenReturn(Optional.empty());

        var domainService = new DomainService(port);
        getAnimalUseCaseService = new GetAnimalUseCaseService(domainService);
    }

    @Test
    void use_case_succeeds() {
        when(port.getById(ID)).thenReturn(Optional.of(new Cat(ID, "test")));
        assertThat(getAnimalUseCaseService.query(ID)).isNotNull();
    }

    @Test
    void use_case_finds_nothing() {
        assertThrows(NotFoundException.class, () -> getAnimalUseCaseService.query(UUID.randomUUID()));
    }
}
