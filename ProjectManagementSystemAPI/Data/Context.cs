using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.Data
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }        
    }
}
