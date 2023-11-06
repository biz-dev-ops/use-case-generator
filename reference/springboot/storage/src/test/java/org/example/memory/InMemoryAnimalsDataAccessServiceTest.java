package org.example.memory;

import org.example.domain.AnimalsDataAccessPort;
import org.example.types.Cat;
import org.example.types.Dog;
import org.example.types.Kind;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;

import java.util.Optional;
import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

class InMemoryAnimalsDataAccessServiceTest {
    private AnimalsDataAccessPort port;

    @BeforeEach
    void setUp() {
        port = new InMemoryAnimalsDataAccessService();
    }

    @Test
    void getById_finds_animal() {
        var id = port.createNewAnimalAndReturnId(new Cat("test"));

        assertThat(port.getById(id)).isNotEmpty();
    }

    @Test
    void getById_returns_empty_if_animal_is_not_found() {
        assertThat(port.getById(UUID.randomUUID())).isEmpty();
    }

    @Test
    void findByKind_finds_animal_by_kind() {
        port.createNewAnimalAndReturnId(new Cat("test"));

        // finds Animal
        assertThat(port.findByKind(Optional.empty(), Pageable.unpaged())).isNotEmpty();
        // finds Cat
        assertThat(port.findByKind(Optional.of(Kind.CAT), Pageable.unpaged())).isNotEmpty();
        // does not find Dog
        assertThat(port.findByKind(Optional.of(Kind.DOG), Pageable.unpaged())).isEmpty();
    }

    @Test
    void findByKind_respects_page_request() {
        port.createNewAnimalAndReturnId(new Cat("a"));
        port.createNewAnimalAndReturnId(new Dog("b"));

        assertThat(port.findByKind(Optional.empty(), PageRequest.of(1, 1))).hasSize(1);
    }

    @Test
    void createNewAnimalAndReturnId_succeeds() {
        var id = assertDoesNotThrow(() -> port.createNewAnimalAndReturnId(new Cat("test")));
        assertThat(id).isNotNull();
    }

    @Test
    void deleteById_deletes_existing_animal() {
        var id = port.createNewAnimalAndReturnId(new Cat("a"));

        assertThat(port.deleteById(id)).isTrue();
        assertThat(port.getById(id)).isEmpty();
    }

    @Test
    void deleteById_ignores_non_existing_animal() {
        assertThat(port.deleteById(UUID.randomUUID())).isFalse();
    }

    @Test
    void deleteByKind_succeeds() {
        var catId = port.createNewAnimalAndReturnId(new Cat("a"));
        var dogId = port.createNewAnimalAndReturnId(new Dog("b"));

        assertThat(port.deleteByKind(Optional.of(Kind.CAT))).isEqualTo(1);
        assertThat(port.getById(catId)).isEmpty();
        assertThat(port.getById(dogId)).isNotEmpty();
    }
}
