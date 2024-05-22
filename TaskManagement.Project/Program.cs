using TaskManagement.Data;
using TaskManagement.Project.GraphQL.Mutation;
using TaskManagement.Project.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .AddTypeExtensionsFromFile("./scheme.graphql");
    
builder.Services.AddSingleton<MasterDbContext>();

var app = builder.Build();


app.MapGraphQL();


app.Run();