using TaskManagement.Data;

namespace TaskManagement.Project.GraphQL.Query;

public sealed partial class Query
{
    private readonly MasterDbContext _dbcontext;
    
    public Query(MasterDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
}