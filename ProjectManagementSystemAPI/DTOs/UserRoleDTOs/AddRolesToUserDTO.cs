using ProjectManagementSystemAPI.Enum;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.DTOs.UserRoleDTOs
{
    public class AddRolesToUserDTO
    {
        public List<int> RoleIds { get; set; }
        public int UserId { get; set; }
    }
}
