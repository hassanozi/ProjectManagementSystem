using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.ProjectUser.Command;
using ProjectManagementSystemAPI.CQRS.ProjectUser.Query;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserProjectController : BaseController
    {
        public UserProjectController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost("AddUserProject")]
        public async Task<ResponseViewModel> AddUserProject(UserProjectDTO userProjectDTO)
        {
           var result = await _mediator.Send(new AssignUserInProjectCommand(userProjectDTO));
            return ResponseViewModel.Success(result);
        }
        [HttpGet]
        public async Task<ResponseViewModel> GetUserProject(UserProjectDTO userProjectDTO)
        {
           var result = await  _mediator.Send( new GetUserProjectQueryById( userProjectDTO));

            return ResponseViewModel.Success(result);
        }
    }
}
