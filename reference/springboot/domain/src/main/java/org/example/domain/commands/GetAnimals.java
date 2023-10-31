package org.example.domain.commands;

import org.example.domain.AnimalsDataAccessPort;
import org.example.types.Animal;
import org.example.types.Kind;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.lang.Nullable;

import java.util.Objects;
import java.util.Optional;

public class GetAnimals<T> extends CollectionUseCase<GetAnimals<T>> {
    private final Class<T> kindSafe;
    private final Pageable page;

    GetAnimals(Class<T> clazz, Pageable page) {
        this.kindSafe = Objects.requireNonNull(clazz);
        this.page = page;
        ofKind(Kind.byClass(clazz));
    }

    public <S extends Animal> GetAnimals<S> ofKind(Class<S> klass) {
        return new GetAnimals<>(klass, page);
    }

    @Override
    public GetAnimals<T> ofKind(@Nullable Kind kind) {
        if (kind != null && !kindSafe.isAssignableFrom(kind.getType())) {
            throw new IllegalArgumentException("Kind filter is incompatible"); // bad coding
        }
        return super.ofKind(kind);
    }

    @Override
    protected GetAnimals<T> self() {
        return this;
    }

    public Page<T> execute(AnimalsDataAccessPort dao) {
        return dao.findByKind(Optional.ofNullable(getKind()), page)
            .map(kindSafe::cast);
    }
}
