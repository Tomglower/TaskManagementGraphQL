using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.DAL;
using TaskManagement.UserService.GraphQL.Mutation;
using TaskManagement.UserService.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddSingleton<UserDbContext>();
var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var logger = services.GetRequiredService<ILogger<Program>>();
//
//     try
//     {
//         var dbContext = services.GetRequiredService<UserDbContext>();
//         dbContext.Database.Migrate();
//         logger.LogInformation("Миграции успешно применены");
//     }
//     catch (Exception ex)
//     {
//         logger.LogError(ex, "Ошибка применения миграций: {Message}", ex.Message);
//     }
// }

app.MapGraphQL();

app.Run();