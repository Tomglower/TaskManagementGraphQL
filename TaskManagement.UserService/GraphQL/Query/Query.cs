
using TaskManagement.Data;

namespace TaskManagement.UserService.GraphQL.Query;

public sealed partial class Query
{
    private readonly MasterDbContext _dbContext;
    private readonly ILogger<Query> _logger;

    public Query(MasterDbContext dbContext,ILogger<Query> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
}