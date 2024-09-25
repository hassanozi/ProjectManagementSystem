using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.DTOs.RoleFeatureDTOs
{
    public class AddFeaturesToRuleDTO
    {
        public List<Feature> Features { get; set; }
        public int RoleId { get; set; }
    }
}
