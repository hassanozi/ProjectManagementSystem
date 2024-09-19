namespace ProjectManagementSystemAPI.DTO.Users
{
    public class UserReturnDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

     
    }
}
