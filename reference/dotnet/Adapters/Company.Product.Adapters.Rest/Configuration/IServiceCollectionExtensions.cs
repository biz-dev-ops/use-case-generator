namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
    {
        services
            .ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
                options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();
                options.ConfigureJsonPolymorphic();
                options.OperationFilter<Vernou.Swashbuckle.HttpResultsAdapter.HttpResultsOperationFilter>();
            });

        services
            .AddSwaggerGen()
            .AddControllers(options => options.Filters.Add(
                new NotFoundFilterAttribute()
            ));

        return services;
    }

    // BEGIN: Swashbuckle does not support Json Polymorphic: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/2671
    private static void ConfigureJsonPolymorphic(this SwaggerGenOptions options)
    {
        options.SelectDiscriminatorNameUsing(baseType => baseType.GetCustomAttribute<JsonPolymorphicAttribute>()?.TypeDiscriminatorPropertyName);
        options.SelectSubTypesUsing(baseType => baseType.GetCustomAttributes<JsonDerivedTypeAttribute>().Select(s => s.DerivedType));

        options.SelectDiscriminatorValueUsing(subType => subType.GetParentTypes()
            .Select(t => t.GetCustomAttributes<JsonDerivedTypeAttribute>()
                .Where(s => s.DerivedType == subType)
                .Select(s => s.TypeDiscriminator?.ToString())
                .SingleOrDefault()
            )
            .Where(s => !string.IsNullOrEmpty(s))
            .FirstOrDefault() ?? subType.Name
        );
    }

    private static IEnumerable<Type> GetParentTypes(this Type type)
    {
        if (type == null)
        {
            yield break;
        }

        foreach (var i in type.GetInterfaces())
        {
            yield return i;
        }

        var currentBaseType = type.BaseType;
        while (currentBaseType != null)
        {
            yield return currentBaseType;
            currentBaseType = currentBaseType.BaseType;
        }
    }
     // END: Swashbuckle does not support Json Polymorphic: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/2671
}