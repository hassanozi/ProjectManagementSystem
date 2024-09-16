using ProjectManagementSystemAPI.Constants.Enum;

namespace ProjectManagementSystemAPI.Model
{
    public class RoleFeature : BaseModel
    {
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public Feature Feature { get; set; }
    }
}
