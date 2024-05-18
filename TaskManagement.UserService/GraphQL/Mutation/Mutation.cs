using TaskManagement.UserService.DAL;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    private readonly UserDbContext _dbContext;

    public Mutation(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}