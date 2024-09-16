
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
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int RoleID { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
