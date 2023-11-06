package org.example.domain.commands;

import org.example.domain.AnimalsDataAccessPort;

import java.util.UUID;

public interface DeleteAnimal {

    static DeleteAnimal byId(UUID id) {
        return dao -> dao.deleteById(id);
    }

    void execute(AnimalsDataAccessPort dao);
}
