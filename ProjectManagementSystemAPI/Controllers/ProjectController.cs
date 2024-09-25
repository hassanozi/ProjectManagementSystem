using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Commands;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.CQRS.Tasks.Query;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Enum;
using ProjectManagementSystemAPI.Filters;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.ViewModels.ProjectViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.CreateProject })]
        public async Task<ResponseViewModel> CreateProject(AddProjectViewModel viewModel)
        {
            var projectDTO = viewModel.MapOne<AddProjectDTO>();
            var command = new AddProjectCommand(projectDTO);
            var result = await _mediator.Send(command);
            return ResponseViewModel.Success(result);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel> GetSingleProject(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));
            var mappedProject = project.MapOne<ProjectViewModel>();
            return ResponseViewModel.Success(mappedProject);
        }

        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.ViewAllProjects })]
        public async Task<ResponseViewModel> GetProjectsList()
        {
            var projects = await _mediator.Send(new GetProjectsListQuery());
            var mappedProjects = projects.Select(x => x.MapOne<ProjectViewModel>());
            return ResponseViewModel.Success(mappedProjects);
        }
        [HttpGet]
        public async Task<ResponseViewModel> GetProjectNumber()
        {
            var ProjectNo = await _mediator.Send(new GetProjectCountQuery());

            return ResponseViewModel.Success(ProjectNo,"you get project count successfully");
        }
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel>> GetAllPag(ProjectDTO project)
        {
            

            var result = await _mediator.Send(new GetAllProjectQuery(project));
            return Ok(result);
        }
    }
}
