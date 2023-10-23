
namespace Company.Product.Adapters.Rest.Configuration;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder ConfigureAdaptersRest(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app
                .UseDeveloperExceptionPage()
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product v1"));
        }

        return app
            .UseHttpsRedirection()
            .UseRouting()            

            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}