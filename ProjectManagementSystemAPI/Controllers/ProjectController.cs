using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Project;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<ActionResult<ResultDTO>> AddProject(AddProjectDTO addProjectDTO)
        {
            var result = await  _mediator.Send(addProjectDTO);
            return Ok(result);
        }

        [HttpGet]

        public async Task<ActionResult<ResultDTO>> getProjectById(int id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(id));
            return Ok(result);
        }
    }
}
