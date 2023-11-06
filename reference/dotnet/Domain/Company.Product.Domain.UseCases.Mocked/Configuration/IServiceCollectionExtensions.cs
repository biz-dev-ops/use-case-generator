using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Domain.UseCases.Mocked.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainUseCasesMocked(this IServiceCollection services)
        {
            return services
                .AddSingleton<ICreateAnimalUseCase, CreateAnimalUseCaseMock>()
                .AddSingleton<IGetAnimalsUseCase, GetAnimalsUseCaseMock>()
                .AddSingleton<IGetAnimalUseCase, GetAnimalUseCaseMock>()
                .AddSingleton<AnimalStore>();
        }
    }
}