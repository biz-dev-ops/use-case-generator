namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
    {
        services
            .AddAdaptersRestGenerated();

        return services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "application", Version = "v1" });
            });
    }
}