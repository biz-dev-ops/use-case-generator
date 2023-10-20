using Company.Product.Domain.UseCases.Types;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });

                c.UseAllOfForInheritance();
                c.UseOneOfForPolymorphism();

                c.SelectSubTypesUsing(baseType =>
                    baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType) || baseType.IsAssignableFrom(type))
                );
            });
    }
}