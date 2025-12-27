using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration);

    builder.Services.AddControllers(options =>
    {
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

