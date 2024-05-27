using Microsoft.EntityFrameworkCore;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    [GraphQLName("AuthenticateUser")]
    public async Task<bool> AuthenticateUser(AuthInput input)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == input.Username);
        if (user != null && BCrypt.Net.BCrypt.Verify(input.Password, user.PasswordHash))
        {
            return true;
        }
        return false;
    }
    public record AuthInput(string Username, string Password);
}