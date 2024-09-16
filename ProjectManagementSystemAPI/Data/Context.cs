using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.Data
{
    public class Context : DbContext 
    {
        public Context( )  
        {

        }
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }        
    }
}
