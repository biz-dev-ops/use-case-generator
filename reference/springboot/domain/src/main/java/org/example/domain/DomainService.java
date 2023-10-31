package org.example.domain;

import lombok.RequiredArgsConstructor;
import org.example.domain.commands.*;
import org.springframework.data.domain.Page;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class DomainService {
    private final AnimalsDataAccessPort animalsDataAccessPort;

    public <T> T query(GetAnimal<T> query) {
        return query.execute(animalsDataAccessPort);
    }

    public <T> Page<T> query(GetAnimals<T> query) {
        return query.execute(animalsDataAccessPort);
    }

    @Transactional
    public <T> T execute(CreateAnimal<T> command) {
        return command.execute(animalsDataAccessPort);
    }

    @Transactional
    public void execute(DeleteAnimal command) {
        command.execute(animalsDataAccessPort);
    }

    @Transactional
    public <T> T execute(DeleteAnimals<T> command) {
        return command.execute(animalsDataAccessPort);
    }
}
