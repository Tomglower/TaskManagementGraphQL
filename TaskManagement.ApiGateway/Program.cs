using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using TaskManagement.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MasterDbContext>();
builder.Services.AddOcelot();
var app = builder.Build();

app.UseOcelot();
app.MapGet("/", () => "Hello World!");

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