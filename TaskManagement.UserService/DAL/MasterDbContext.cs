using Microsoft.EntityFrameworkCore;
using TaskManagement.UserService.DAL.Models;

namespace TaskManagement.UserService.DAL
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private readonly IConfiguration _configuration;


        public UserDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("ConString"));
        }
     
    }
}