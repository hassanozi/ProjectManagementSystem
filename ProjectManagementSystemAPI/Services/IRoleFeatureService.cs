using ProjectManagementSystemAPI.Constants.Enum;

namespace ProjectManagementSystemAPI.Services
{
    public interface IRoleFeatureService
    {
        bool HasAccess(int roleID, Feature feature);
    }
}
