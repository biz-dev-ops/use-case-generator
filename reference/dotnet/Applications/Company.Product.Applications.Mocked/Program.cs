var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAdaptersRest()
    .AddDomainUseCasesMocked();

var app = builder.Build();

app
    .ConfigureAdaptersRest(builder.Configuration, app.Environment);

app.Run();