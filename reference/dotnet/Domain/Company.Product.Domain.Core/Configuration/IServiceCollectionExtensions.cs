namespace Company.Product.Domain.Core.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDomainCore(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICreateAnimalUseCase, CreateAnimalUseCase>()
            .AddSingleton<IGetAnimalsUseCase, GetAnimalsUseCase>()
            .AddSingleton<IGetAnimalUseCase, GetAnimalUseCase>();
    }
}