using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.DAL;
using TaskManagement.UserService.DAL.Models;

namespace TaskManagement.UserService.GraphQL.Query;

public sealed partial class Query
{
  
    [GraphQLName("GetUsers")]
    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
        

    }
}