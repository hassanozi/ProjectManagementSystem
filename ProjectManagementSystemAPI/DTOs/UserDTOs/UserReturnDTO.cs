namespace ProjectManagementSystemAPI.DTOs.UserDTOs
{
    public class UserReturnDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int RoleID { get; set; }
    }
}
