var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRestAdapterServices()
    .AddDomainUseCasesMocks();

var app = builder.Build();

app
    .ConfigureRestAdapter(builder.Configuration, app.Environment);

app.Run();