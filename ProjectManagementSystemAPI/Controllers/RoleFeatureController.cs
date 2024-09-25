using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.ProjectUser.Command;
using ProjectManagementSystemAPI.CQRS.RoleFeatures.Commands;
using ProjectManagementSystemAPI.CQRS.UserRoles.Orchestrators;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.DTOs.RoleFeatureDTOs;
using ProjectManagementSystemAPI.DTOs.UserRoleDTOs;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleFeatureController : BaseController
    {
        public RoleFeatureController(ControllereParameters controllereParameters) : base(controllereParameters) { }

        [HttpPost]
        public async Task<ResponseViewModel> AssignFeaturesToRole(AddFeaturesToRuleDTO addFeaturesToRuleDTO)
        {
            var result = await _mediator.Send(new AssignFeaturesToRoleOrchestrator(addFeaturesToRuleDTO));
            return ResponseViewModel.Success(result);
        }
    }
}
