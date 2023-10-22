namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
    {
        services
            .AddControllers();

        return services
            .AddBizDevOpsAdaptersSwashbuckle()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
            });
    }
}