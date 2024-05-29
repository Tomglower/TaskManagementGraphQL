using TaskManagement.Data;
using TaskManagement.Task.GraphQL.Mutation;
using TaskManagement.Task.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddSingleton<MasterDbContext>();

var app = builder.Build();

app.MapGraphQL();

app.Run();