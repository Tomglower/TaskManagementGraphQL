using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Project.GraphQL.Mutation;

public sealed partial class Mutation
{
    [GraphQLDescription("DeleteProject")]
    public async Task<bool> DeleteProject(Guid projectId)
    {
        var deletedProject = await _dbContext.Projects
            .Where(id => id.Id == projectId)
            .FirstOrDefaultAsync();
        
        if (deletedProject is not null)
        {
            _dbContext.Projects.Remove(deletedProject);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;

    }
}