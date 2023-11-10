namespace Company.Product.Adapters.Rest.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptersRestGenerated(this IServiceCollection services)
    {
        return services
            .Configure<MvcOptions>(options => {
                options.Filters.Add<NotAuthenticatedExceptionFilterAttribute>();
                options.Filters.Add<NotAuthorizedExceptionFilterAttribute>();
                options.Filters.Add<NotFoundFilterExceptionAttribute>();
            });
    }
}