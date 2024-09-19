using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Query;
using ProjectManagementSystemAPI.ViewModels.Projects;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            var result = await _mediator.Send(new GetProjectsListQuery());

            return (IEnumerable<ProjectViewModel>)result;
        }
    }
}
