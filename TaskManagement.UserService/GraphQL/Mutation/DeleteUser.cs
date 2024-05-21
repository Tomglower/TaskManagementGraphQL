using Microsoft.EntityFrameworkCore;

namespace TaskManagement.UserService.GraphQL.Mutation;

public sealed partial  class Mutation
{
    [GraphQLName("DeleteUser")]
    public async Task<bool> DeleteUser(DeleteUserInput input )
    {
        var user = await _dbContext.Users
            .Where(u => u.Id == input.id)
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            return false;
        }

        return true;
    }

    public record DeleteUserInput(Guid id);
}