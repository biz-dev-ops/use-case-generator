namespace Company.Product.Domain.UseCases.Types
{
    public interface AnimalVisitor<T>
    {
        T Visit(Cat cat);
        T Visit(Cow cow);
        T Visit(Dog dog);
    }
}