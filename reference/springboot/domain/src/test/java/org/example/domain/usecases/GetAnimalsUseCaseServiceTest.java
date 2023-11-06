package org.example.domain.usecases;

import org.example.domain.AnimalsDataAccessPort;
import org.example.domain.DomainService;
import org.example.types.Animal;
import org.example.types.Cat;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;

import java.util.List;
import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class GetAnimalsUseCaseServiceTest {
    private AnimalsDataAccessPort port;
    private GetAnimalsUseCaseService getAnimalsUseCaseService;

    @BeforeEach
    void setUp() {
        port = mock(AnimalsDataAccessPort.class);
        Page<Animal> page = new PageImpl<>(List.of(new Cat(UUID.randomUUID(), "test")));
        when(port.findByKind(any(), any(Pageable.class))).thenReturn(page);

        var domainService = new DomainService(port);
        getAnimalsUseCaseService = new GetAnimalsUseCaseService(domainService);
    }

    @Test
    void use_case_succeeds() {
        assertThat(getAnimalsUseCaseService.query(PageRequest.of(0, 10))).isNotEmpty();
    }
}
