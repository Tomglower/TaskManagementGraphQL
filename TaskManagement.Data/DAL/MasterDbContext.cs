using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.DAL.Models;
using Microsoft.Extensions.Configuration;
using Task = TaskManagement.Data.DAL.Models.Task;

namespace TaskManagement.Data;

public class MasterDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    private readonly IConfiguration _configuration;


    public MasterDbContext(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("ConString"));
    }
     
}