namespace Company.Product.Domain.UseCases.Types
{
    /*
    oneOf:
        - $ref: "#/dog"
        - $ref: "#/cat"
        - $ref: "#/cow"
    */
    public interface AnimalVisitor<T>
    {
        T Visit(Cat cat);
        T Visit(Cow cow);
        T Visit(Dog dog);
    }
}