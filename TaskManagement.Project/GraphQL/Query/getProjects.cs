using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.DAL.Models;

namespace TaskManagement.Project.GraphQL.Query;

public sealed partial class Query
{
    [GraphQLName("GetProjects")]
    public async Task<List<Data.DAL.Models.Project>> GetUsers()
    {
        return await _dbcontext.Projects.ToListAsync();
        

    }
}