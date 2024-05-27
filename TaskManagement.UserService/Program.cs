using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.UserService.GraphQL.Mutation;
using TaskManagement.UserService.GraphQL.Query;
using TaskManagement.Data;
using TaskManagement.Data.DAL.Models;
using TaskManagement.UserService.JwtToken;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddAuthorization();

// Регистрация контекста базы данных
builder.Services.AddSingleton<MasterDbContext>();

var app = builder.Build();

// Использование аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// Настройка маршрутизации GraphQL
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
