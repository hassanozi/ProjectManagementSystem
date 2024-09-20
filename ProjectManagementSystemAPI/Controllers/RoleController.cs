using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Roles.Command;
using ProjectManagementSystemAPI.CQRS.Roles.Query;
using ProjectManagementSystemAPI.CQRS.Tasks.Commands;
using ProjectManagementSystemAPI.DTOs.RoleDTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Exceptions;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.ViewModels.RoleViewModel;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseViewModel>> CreateRole(AddRoleViewModel viewModel)
        {
            var addRoleDTO = viewModel.MapOne<AddRoleDTO>();
            var command = new CreateRoleCommand(addRoleDTO);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel> GetSingleRole(int id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));
            var mappedRole = role.MapOne<RoleViewModel>();
            return ResponseViewModel.Success(mappedRole);
        }
    }
}
