using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.CQRS.Tasks.Commands;
using ProjectManagementSystemAPI.CQRS.Tasks.Query;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [HttpPost("AssignUserInTask")]

        public async Task<ActionResult<ResponseViewModel>> AssignUserInTask(UserTaskDTO userTaskDTO)
        {
            if (userTaskDTO == null)
            {
                return ResponseViewModel.Faliure("Fill data correctly");

            }

            var result = await _mediator.Send(new AssignUserInTaskCommand(userTaskDTO));
            return Ok(result);
        }
        [HttpPost("GetAllPag")]

        public async Task<ActionResult<ResponseViewModel>> GetAllPag(TaskDTO TaskDTO)
        {
            if (TaskDTO == null)
            {
                return ResponseViewModel.Faliure("Fill data correctly");

            }

            var result = await _mediator.Send(new GetAllTasksQuery(TaskDTO));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ResponseViewModel> GetTaskNumber()
        {
            var TasksNo = await _mediator.Send(new GetTasksCountQuery());

            return ResponseViewModel.Success(TasksNo, "you get Tasks count successfully");
        }

        [HttpGet]
        public async Task<ResponseViewModel> GetAverageTasksInProgressStatus()
        {
            var InProgressTasksNo = await _mediator.Send(new GetAverageProgressStatusTaskQuery());

            return ResponseViewModel.Success(InProgressTasksNo, "you get Tasks count successfully");
        }
    }
}
