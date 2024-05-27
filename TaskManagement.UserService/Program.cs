using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.GraphQL.Mutation;
using TaskManagement.UserService.GraphQL.Query;
using TaskManagement.Data;
using TaskManagement.Data.DAL.Models;

var builder = WebApplication.CreateBuilder(args);


 builder.Services
     .AddGraphQLServer()
     .AddQueryType<Query>()
     .AddMutationType<Mutation>();


builder.Services.AddSingleton<MasterDbContext>();

var app = builder.Build();

app.MapGraphQL();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var dbContext = services.GetRequiredService<MasterDbContext>();
        dbContext.Database.Migrate();
        logger.LogInformation("Миграции успешно применены");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ошибка применения миграций: {Message}", ex.Message);
    }
}
app.Run();