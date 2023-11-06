package org.example.adapters.rest;

import org.example.adapters.rest.dto.CreateAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalResponse;
import org.example.adapters.rest.dto.GetAnimalsResponse;
import org.example.adapters.rest.dto.LinksDto;
import org.example.domain.usecases.types.Animal;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.web.util.UriComponentsBuilder;

import java.net.URI;
import java.util.List;
import java.util.UUID;

public class ResponseMapper {

    public static Pageable limitOffsetToPageable(int limit, int offset) {
        int page = offset / limit;
        return PageRequest.of(page, limit);
    }

    public static GetAnimalsResponse mapGetAnimalsResponse(Page<Animal> animals) {
        var response = new GetAnimalsResponse();
        response.setAnimals(DomainDtoMapper.map(animals));
        response.setMessages(List.of()); // why?

        var links = new LinksDto();
        if (animals.hasNext()) {
            var nextPage = animals.nextPageable();
            var nextLink = UriComponentsBuilder.fromPath("/animals")
                .queryParam("limit", nextPage.getPageSize())
                .queryParam("offset", nextPage.getOffset())
                .build()
                .toUri();
            links.setNext(nextLink);
        }
        response.setLinks(links);
        return response;
    }

    public static GetAnimalResponse mapGetAnimalResponse(Animal animal) {
        var response = new GetAnimalResponse();
        response.setMessages(List.of()); // why GET response contains .messages?
        response.setAnimal(DomainDtoMapper.map(animal));
        return response;
    }

    public static CreateAnimalResponse mapCreateAnimalResponse(URI location) {
        var response = new CreateAnimalResponse();
        response.setLocation(location);
        return response;
    }
}
