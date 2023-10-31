package org.example.rest;

import org.example.types.Animal;
import org.example.types.Cat;
import org.example.types.Dog;
import org.example.usecases.CreateAnimalUseCase;
import org.example.usecases.GetAnimalUseCase;
import org.example.usecases.GetAnimalsUseCase;
import org.example.usecases.NotFoundException;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.Pageable;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import java.util.List;
import java.util.UUID;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@WebMvcTest(AnimalsController.class)
class AnimalsControllerTest {
    private static final UUID ID = UUID.randomUUID();
    private static final UUID ID_NOT_FOUND = UUID.randomUUID();

    @Autowired
    private MockMvc mvc;
    @MockBean
    private GetAnimalUseCase getAnimalUseCase;
    @MockBean
    private GetAnimalsUseCase getAnimalsUseCase;
    @MockBean
    private CreateAnimalUseCase createAnimalUseCase;

    @BeforeEach
    void setUp() {
        var cat = new Cat(ID, "cat");
        var dog = new Dog(UUID.randomUUID(), "dog");
        var animals = List.of(cat, dog);
        Page<Animal> page = new PageImpl<>(animals);

        when(getAnimalUseCase.query(ID)).thenReturn(cat);
        when(getAnimalUseCase.query(ID_NOT_FOUND)).thenThrow(new NotFoundException("not found"));
        when(getAnimalsUseCase.query(any(Pageable.class))).thenReturn(page);
        when(createAnimalUseCase.execute(any(Animal.class))).thenReturn(ID);
    }

    @Test
    void getAnimals() throws Exception {
        mvc.perform(get("/animals")
                .queryParam("limit", "10")
                .queryParam("offset", "0"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.animals").isArray())
            .andExpect(jsonPath("$.animals[0].animal_id").isNotEmpty())
            .andExpect(jsonPath("$.animals[1].animal_id").isNotEmpty());
    }

    @Test
    void getAnimals_requires_offset_and_limit() throws Exception {
        mvc.perform(get("/animals"))
            .andExpect(status().isBadRequest());
    }

    @Test
    void getAnimal_succeeds() throws Exception {
        mvc.perform(get("/animals/{animal_id}", ID))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.animal.object_type").value("cat"))
            .andExpect(jsonPath("$.animal.animal_id").value(ID.toString()))
            .andExpect(jsonPath("$.animal.b").value("cat"));
    }

    @Test
    void getAnimal_not_found() throws Exception {
        mvc.perform(get("/animals/{animal_id}", ID_NOT_FOUND))
            .andExpect(status().isNotFound())
            .andExpect(jsonPath("$.messages").isArray())
            .andExpect(jsonPath("$.messages[0].type").value("ERROR"))
            .andExpect(jsonPath("$.messages[0].message").value("not found"));
    }

    @Test
    void createAnimal() throws Exception {
        var json = """
            {
                "object_type": "dog",
                "a": "dog's name"
            }
            """;
        var path = "/animals/%s".formatted(ID);
        mvc.perform(post("/animals")
                .contentType(MediaType.APPLICATION_JSON)
                .content(json))
            .andExpect(status().isCreated())
            .andExpect(header().string("Location", path))
            .andExpect(jsonPath("$.location").value(path));
    }
}
