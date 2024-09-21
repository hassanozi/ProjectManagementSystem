using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Tasks.Commands;
using ProjectManagementSystemAPI.CQRS.Tasks.Queries;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.ViewModels.TaskViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddTask")]

        public async Task<ActionResult<ResponseViewModel>> AddTask(AddTaskDTO addTaskDTO)
        {
            if(addTaskDTO == null)
            {
                return ResponseViewModel.Faliure("Fill data correctly");

            }

            var result = await _mediator.Send(new AddTaskOrchestratorCommand( addTaskDTO));
            return Ok(result);
        }


        [HttpGet]
        public async Task<IEnumerable<TaskViewModel>> GetAllTasks()
        {
            var result = await _mediator.Send(new GetTasksListQuery());

            return (IEnumerable<TaskViewModel>)result;
        }
    }
}
