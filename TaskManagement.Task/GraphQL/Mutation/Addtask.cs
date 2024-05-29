using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskStatus = TaskManagement.Data.DAL.Models.TaskStatus;

namespace TaskManagement.Task.GraphQL.Mutation;

public sealed partial class Mutation
{
    public async Task<bool> AddTask(TaskInput input)
    {
        var projectExists = await _dbContext.Projects.AnyAsync(p => p.Id == input.ProjectId);
        var userExists = await _dbContext.Users.AnyAsync(u => u.Id == input.AssignedUserId);

        if (!projectExists || !userExists)
        {
            // Если связанные сущности не найдены, можно вернуть false или кинуть исключение
            return false;
        }
        
        var task = new Data.DAL.Models.Task()
        {
            Id = Guid.NewGuid(),
            Title = input.Title,
            Description = input.Description,
            CreatedAt = DateTime.UtcNow,
            DueDate = input.DueDate,
            ProjectId = input.ProjectId,
            AssignedUserId = input.AssignedUserId,
            Status = input.Status
        };
        _dbContext.Tasks.Add(task);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ;
    } 
}

public record TaskInput(string Title, string Description, DateTime DueDate, Guid ProjectId, Guid AssignedUserId,
    TaskStatus Status);

