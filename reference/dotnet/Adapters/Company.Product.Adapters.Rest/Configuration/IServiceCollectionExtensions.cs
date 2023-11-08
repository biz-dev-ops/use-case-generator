namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRest(this IServiceCollection services)
    {
        services
            .Configure<MvcOptions>(options => {
                options.Filters.Add(
                    new NotFoundFilterAttribute()
                );
            })
            .ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
                options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();
                options.ConfigureJsonPolymorphicAdapter();
                options.ConfigureHttpResultsAdapter();
                options.OperationFilter<Vernou.Swashbuckle.HttpResultsAdapter.HttpResultsOperationFilter>();
            });


        services
            .AddSwaggerGen()
            .AddControllers();

        return services;
    }

    // BEGIN: Swashbuckle does not support HttpResults: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2595
    private static void ConfigureHttpResultsAdapter(this SwaggerGenOptions options)
    {
        options.OperationFilter<Vernou.Swashbuckle.HttpResultsAdapter.HttpResultsOperationFilter>();
    }
    // END: Swashbuckle does not support HttpResults: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2595

    // BEGIN: Swashbuckle does not support Json Polymorphic: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/2671
    private static void ConfigureJsonPolymorphicAdapter(this SwaggerGenOptions options)
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