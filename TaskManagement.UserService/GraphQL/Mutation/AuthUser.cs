using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.JwtToken;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{

    [GraphQLName("AuthenticateUser")]
    public async Task<AuthPayload> AuthenticateUser(AuthInput input)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == input.Username);
        if (user != null && BCrypt.Net.BCrypt.Verify(input.Password, user.PasswordHash))
        {
            var token = _jwtTokenService.GenerateToken(input.Username);
            return new AuthPayload(token, null);
        }
        return new AuthPayload(null, "Invalid username or password");
    }

    public record AuthInput(string Username, string Password);
    public record AuthPayload(string? Token, string? ErrorMessage);

}