using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.Model;
using System.Diagnostics;
using System.Reflection;

namespace ProjectManagementSystemAPI.Data
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }        
    }
}
