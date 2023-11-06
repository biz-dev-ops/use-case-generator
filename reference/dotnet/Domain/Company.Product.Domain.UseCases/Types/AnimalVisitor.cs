namespace Company.Product.Domain.UseCases.Types
{
    public interface AnimalVisitor<T>
    {
        T VisitCat(Cat cat);
        T VisitCow(Cow cow);
        T VisitDog(Dog dog);
    }
}