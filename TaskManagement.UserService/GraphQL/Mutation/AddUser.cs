using TaskManagement.Data.DAL.Models;
using BCrypt.Net;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial class Mutation
{
    [GraphQLName("AddUser")]
    public async Task<UserPayload> AddUser(UserInput input)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = input.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(input.PasswordHash),
            Email = input.Email,
            CreatedAt = DateTime.UtcNow
        };
         _dbContext.Users.Add(user);
         await _dbContext.SaveChangesAsync();
         return new UserPayload(user);
    }
    
    public record UserInput(string Username, string Email, string PasswordHash);
    public record UserPayload(User record);
}