using TaskManagement.UserService.DAL;

namespace TaskManagement.UserService.GraphQL.Query;

public sealed partial class Query
{
    private readonly UserDbContext _dbContext;
    private readonly ILogger<Query> _logger;

    public Query(UserDbContext dbContext,ILogger<Query> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
}