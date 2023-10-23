using Company.Product.Adapters.Rest.Attributes;

namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
    {
        services
            .AddBizDevOpsAdaptersSwashbuckle()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
            })
            .AddControllers(options => options.Filters.Add(new NotFoundFilterAttribute()));

        return services;
    }
}