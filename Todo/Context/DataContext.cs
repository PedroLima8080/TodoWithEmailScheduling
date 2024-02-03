using Microsoft.EntityFrameworkCore;
using Todo.Data.Models;

namespace Todo.Application.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Status>()
                .HasIndex(u => u.Description)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public DbSet<Todo.Data.Models.Todo> Todo { get; set; }
        public DbSet<Todo.Data.Models.Status> Status { get; set; }

    }
}
