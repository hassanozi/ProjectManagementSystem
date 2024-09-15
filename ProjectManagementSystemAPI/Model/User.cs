
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
        

       
        public List<Claim> Claims { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
