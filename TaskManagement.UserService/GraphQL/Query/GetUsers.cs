using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.DAL;
using TaskManagement.UserService.DAL.Models;

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
    
    [GraphQLName("GetUsers")]
    public async Task<List<User>> GetUsers()
    {
        try
        {
            return await _dbContext.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching users.");
            throw new GraphQLException("An error occurred while fetching users.");
        }
    }
}