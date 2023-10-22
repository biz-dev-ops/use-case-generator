using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Domain.UseCases.Mocks.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainUseCasesMocks(this IServiceCollection services)
        {
            return services
                .AddSingleton<ICreateAnimalUseCase, CreateAnimalUseCaseMock>()
                .AddSingleton<IGetAnimalsUseCase, GetAnimalsUseCaseMock>()
                .AddSingleton<IGetAnimalUseCase, GetAnimalUseCaseMock>()
                .AddSingleton<AnimalStore>();
        }
    }
}