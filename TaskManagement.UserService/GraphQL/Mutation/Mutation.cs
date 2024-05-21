using TaskManagement.Data;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    private readonly MasterDbContext _dbContext;

    public Mutation(MasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}