using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.DAL;
using TaskManagement.UserService.GraphQL.Mutation;
using TaskManagement.UserService.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<UserDbContext>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    ;

var app = builder.Build();

var logger = app.Services.GetService<ILogger<UserDbContext>>();

try
{
    var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<UserDbContext>();
    await dbContext.Database.MigrateAsync();
    logger.LogInformation("Миграции успешно применены");
}
catch (Exception ex)
{
    logger.LogError("Ошибка применения миграций: " + ex.Message);
    return;
}

app.MapGraphQL();

app.Run();