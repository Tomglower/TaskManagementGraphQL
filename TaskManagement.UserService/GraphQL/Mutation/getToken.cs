namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    [GraphQLName("GetToken")]
    public async Task<string> GetToken(string username )
    {
        var token = _jwtTokenService.GenerateToken(username);
        return token;
    }
}