using ProjectManagementSystemAPI.Constants.Enum;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.Services
{
    public class RoleFeatureService : IRoleFeatureService
    {
        private readonly IRepository<RoleFeature> _repository;

        public RoleFeatureService(IRepository<RoleFeature> repository)
        {
            _repository = repository;
        }

        public bool HasAccess(int roleID, Feature feature)
        {
            return _repository.Get(r => !r.Deleted &&
                r.RoleID == roleID && r.Feature == feature).Any();
        }
    }
}
