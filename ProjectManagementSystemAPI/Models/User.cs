
namespace ProjectManagementSystemAPI.Model
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string EmailConfirmationToken { get; set; }
        public DateTime TokenExpiration { get; set; } = new DateTime().AddHours(1);

        public bool IsVerified { get; set; } = false;
        public int? RoleID { get; set; } = 1;
        public List<UserRole> UserRoles { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public List<UserProject> UserProjects { get; set; }
    }
}
