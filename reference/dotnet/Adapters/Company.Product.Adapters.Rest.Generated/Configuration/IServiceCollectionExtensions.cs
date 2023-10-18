using Company.Product.Adapters.Rest.Attributes;
using Company.Product.Adapters.Rest.Resolvers;

using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Adapters.Rest.Configuration
{

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAdaptersRestGenerated(this IServiceCollection services)
        {
            services
                .AddControllers(config =>
                {
                    config.Filters.Add<ValidateModelStateAttribute>();
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.TypeInfoResolver = new PolymorphicTypeResolver();
                });

            return services;
        }
    }
}