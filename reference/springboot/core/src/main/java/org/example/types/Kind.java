package org.example.types;

import lombok.AccessLevel;
import lombok.Getter;
import lombok.RequiredArgsConstructor;

@Getter
@RequiredArgsConstructor(access = AccessLevel.PRIVATE)
public enum Kind {
    CAT(Cat.class),
    COW(Cow.class),
    DOG(Dog.class);

    private final Class<? extends Animal> type;

    /**
     * Returns Kind by domain class.
     *
     * @param clazz domain class
     * @return null if domain class is Animal, otherwise related enum value.
     */
    public static Kind byClass(Class<?> clazz) {
        if (Animal.class.equals(clazz)) {
            return null;
        }

        for (var value : values()) {
            if (value.getType().equals(clazz)) {
                return value;
            }
        }

        throw new IllegalArgumentException("Unknown domain class: %s".formatted(clazz.getSimpleName()));
    }
}
