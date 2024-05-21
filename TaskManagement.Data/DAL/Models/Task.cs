using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Data.DAL.Models;

public class Task
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public Guid ProjectId { get; set; }
    public Guid AssignedUserId { get; set; }
    public TaskStatus Status { get; set; }

    // Navigation properties
    public Project Project { get; set; }
    public User AssignedUser { get; set; }
}

// Enum for task status
public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold
}