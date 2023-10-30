package org.example.domain.usecases;

import org.example.domain.AnimalsDataAccessPort;
import org.example.domain.DomainService;
import org.example.types.Animal;
import org.example.types.Cat;
import org.example.usecases.CreateAnimalUseCase;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class CreateAnimalUseCaseTest {
    private AnimalsDataAccessPort port;
    private CreateAnimalUseCase createAnimalUseCase;

    @BeforeEach
    void setUp() {
        port = mock(AnimalsDataAccessPort.class);
        when(port.createNewAnimalAndReturnId(any(Animal.class))).thenReturn(UUID.randomUUID());

        var domainService = new DomainService(port);
        createAnimalUseCase = new CreateAnimalUseCaseService(domainService);
    }

    @Test
    void use_case_succeeds() {
        var id = createAnimalUseCase.execute(new Cat("test"));
        assertThat(id).isNotNull();
    }

    // TODO: validation failures
}
