package org.example.domain.commands;

import org.example.types.Kind;
import lombok.Getter;
import org.springframework.lang.Nullable;

@Getter
public abstract class CollectionUseCase<T> {
    private Kind kind;

    // TODO: search on shared attributes typesafe
    // TODO: search on model specific attribuutes

    public T ofKind(@Nullable Kind kind) {
        this.kind = kind;
        return self();
    }

    protected abstract T self();
}
