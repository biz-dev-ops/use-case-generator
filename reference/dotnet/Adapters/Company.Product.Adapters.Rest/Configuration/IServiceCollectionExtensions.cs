using Company.Product.Domain.UseCases.Types;

namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
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

        return services
            .AddBizDevOpsAdaptersSwashbuckle()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
            });
    }
}