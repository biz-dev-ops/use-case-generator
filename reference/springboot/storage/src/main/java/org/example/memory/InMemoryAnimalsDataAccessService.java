package org.example.memory;

import org.example.domain.AnimalsDataAccessPort;
import org.example.types.Animal;
import org.example.types.Kind;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.Pageable;

import java.util.HashMap;
import java.util.Map;
import java.util.Optional;
import java.util.UUID;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class InMemoryAnimalsDataAccessService implements AnimalsDataAccessPort {
    private Map<UUID, Animal> animals = new HashMap<>();
    private ReadWriteLock lock = new ReentrantReadWriteLock();
    private Lock readLock = lock.readLock();
    private Lock writeLock = lock.writeLock();

    @Override
    public Optional<Animal> getById(UUID id) {
        readLock.lock();
        try {
            return Optional.ofNullable(animals.get(id));
        } finally {
            readLock.unlock();
        }
    }

    @Override
    public Page<Animal> findByKind(Optional<Kind> kind, Pageable pageable) {
        // FIXME: ignores pageable.getSort() for now, interface is adapted for proper Spring Data use
        readLock.lock();
        try {
            var base = animals.entrySet().stream();
            var filteredAnimals = kind.map(kindValue ->
                base.filter(entry -> kindValue.equals(entry.getValue().getObjectType())))
                .orElse(base)
                .map(Map.Entry::getValue)
                .toList();

            var total = filteredAnimals.size();
            if (pageable.isPaged()) {
                filteredAnimals = filteredAnimals.stream().skip(pageable.getOffset())
                    .limit(pageable.getPageSize())
                    .toList();
            }
            return new PageImpl<>(filteredAnimals, pageable, total);
        } finally {
            readLock.unlock();
        }
    }

    @Override
    public UUID createNewAnimalAndReturnId(Animal animal) {
        writeLock.lock();
        try {
            var id = UUID.randomUUID();
            while (animals.containsKey(id)) {
                id = UUID.randomUUID();
            }
            animals.put(id, animal.cloneWithId(id));
            return id;
        } finally {
            writeLock.unlock();
        }
    }

    @Override
    public boolean deleteById(UUID id) {
        writeLock.lock();
        try {
            return animals.remove(id) != null;
        } finally {
            writeLock.unlock();
        }
    }

    @Override
    public int deleteByKind(Optional<Kind> kind) {
        writeLock.lock();
        try {
            var base = animals.entrySet().stream();
            var filteredIds = kind.map(kindValue ->
                    base.filter(entry -> kindValue.equals(entry.getValue().getObjectType())))
                .orElse(base)
                .map(Map.Entry::getKey)
                .toList();

            filteredIds.forEach(animals::remove);
            return filteredIds.size();
        } finally {
            writeLock.unlock();
        }
    }
}
