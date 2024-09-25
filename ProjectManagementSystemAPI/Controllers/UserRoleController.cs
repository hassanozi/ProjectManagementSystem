using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.UserRoles.Orchestrators;
using ProjectManagementSystemAPI.DTOs.UserRoleDTOs;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        public UserRoleController(ControllereParameters controllereParameters) : base(controllereParameters) { }

        [HttpPost]
        public async Task<ResponseViewModel> AssignRolesToUser(AddRolesToUserDTO addRolesToUserDTO)
        {
            var result = await _mediator.Send(new AssignRolesToUserOrchestrator(addRolesToUserDTO));
            return ResponseViewModel.Success(result);
        }
    }
}
