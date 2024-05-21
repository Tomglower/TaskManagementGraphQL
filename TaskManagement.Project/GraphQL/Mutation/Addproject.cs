namespace TaskManagement.Project.GraphQL.Mutation;

public sealed partial class Mutation
{
    public async Task<ProjectPayload> AddProject(ProjectInput input)
    {

        var project = new Data.DAL.Models.Project()
        {
            Id = Guid.NewGuid(),
            Name = input.name,
            Description = input.description,
            EndDate = input.endDate,
            OwnerId = input.ownerID,
            StartDate = input.startDate,
            CreateDate = DateTime.UtcNow
        };
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        return new  ProjectPayload(project);

    }

// TODO: добавить поле для ownerid автоматом 
    public record ProjectInput(string name, string description, DateTime startDate,  DateTime endDate,  Guid ownerID);
    public record ProjectPayload(Data.DAL.Models.Project project);
    
    
}