using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Domain.UseCases.Mocked.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMockedUseCases(this IServiceCollection services)
        {
            return services
                .AddSingleton<GetAnimalsUseCase, GetAnimalsUseCaseMock>();
        }
    }
}