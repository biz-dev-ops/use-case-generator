package org.example.domain.commands;

import org.example.domain.AnimalsDataAccessPort;
import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;

import java.util.Optional;
import java.util.function.BiFunction;

@RequiredArgsConstructor(access = AccessLevel.PRIVATE)
public class DeleteAnimals<T> extends CollectionUseCase<DeleteAnimals<T>> {
    private final BiFunction<AnimalsDataAccessPort, DeleteAnimals<T>, T> applier;

    public static DeleteAnimals<Integer> andReturnCount() {
        return new DeleteAnimals<>((dao, me) -> dao.deleteByKind(
            Optional.ofNullable(me.getKind())
        ));
    }

    // TODO: andReturnModel() if you need List<Animal> or other effects

    @Override
    protected DeleteAnimals<T> self() {
        return this;
    }

    public T execute(AnimalsDataAccessPort dao) {
        return applier.apply(dao, this);
    }
}
