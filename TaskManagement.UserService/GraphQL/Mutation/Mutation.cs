using TaskManagement.Data;
using TaskManagement.UserService.JwtToken;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    private readonly MasterDbContext _dbContext;
    private readonly IJwtTokenService _jwtTokenService;


    public Mutation(MasterDbContext dbContext,IJwtTokenService jwtTokenService)
    {
        _dbContext = dbContext;
        _jwtTokenService = jwtTokenService;
    }
}