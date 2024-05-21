using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Data.DAL.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid OwnerId { get; set; }

    // Navigation property
    public User Owner { get; set; }
    public ICollection<Task> Tasks { get; set; }
}