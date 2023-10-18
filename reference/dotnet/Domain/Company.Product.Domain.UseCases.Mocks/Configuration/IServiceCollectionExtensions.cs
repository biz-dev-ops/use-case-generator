using Company.Product.Domain.UseCases.Bus;
using Company.Product.Domain.UseCases.Queries;
using Company.Product.Domain.UseCases.Types;

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Domain.UseCases.Mocks.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainUseCasesMocks(this IServiceCollection services)
        {
            return services
                .AddSingleton<IBus, BusMock>()
                .AddSingleton<IQueryHandler<GetAnimals, IEnumerable<Animal>>, GetAnimalsUseCaseHandlerMock>();
        }
    }
}