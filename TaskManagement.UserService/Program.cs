using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.GraphQL.Mutation;
using TaskManagement.UserService.GraphQL.Query;
using TaskManagement.Data;
var builder = WebApplication.CreateBuilder(args);


 builder.Services
     .AddGraphQLServer()
     .AddQueryType<Query>()
     .AddMutationType<Mutation>();

builder.Services.AddSingleton<MasterDbContext>();
var app = builder.Build();



app.MapGraphQL();

app.Run();