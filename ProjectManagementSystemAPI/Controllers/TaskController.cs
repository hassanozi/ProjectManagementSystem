using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.CQRS.Tasks.Commands;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Enum;
using ProjectManagementSystemAPI.Filters;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.ViewModels.TaskViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.CreateTask })]
        public async Task<ActionResult<ResponseViewModel>> AddTask(AddTaskDTO addTaskDTO)
        {
            if(addTaskDTO == null)
            {
                return ResponseViewModel.Failure("Fill data correctly");

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
        [HttpPost("AssignUserInTask")]
        public async Task<ActionResult<ResponseViewModel>> AssignUserInTask(UserTaskDTO userTaskDTO)
        {
            if (userTaskDTO == null)
            {
                return ResponseViewModel.Failure("Fill data correctly");

            }

            var result = await _mediator.Send(new AssignUserInTaskCommand(userTaskDTO));
            return Ok(result);
        }
        [HttpPost("GetAllPag")]

        public async Task<ActionResult<ResponseViewModel>> GetAllPag(TaskDTO TaskDTO)
        {
            if (TaskDTO == null)
            {
                return ResponseViewModel.Failure("Fill data correctly");

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
