using TaskManagement.Data;

namespace TaskManagement.Task.GraphQL.Query;

public sealed partial class Query
{
    private readonly MasterDbContext _dbContext;


    public Query(MasterDbContext dbContext)
    {
        _dbContext = dbContext;
    } 
}