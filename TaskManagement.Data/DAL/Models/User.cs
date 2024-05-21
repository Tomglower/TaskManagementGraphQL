using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Data.DAL.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public ICollection<Project> OwnedProjects { get; set; }
    public ICollection<Task> AssignedTasks { get; set; }
}