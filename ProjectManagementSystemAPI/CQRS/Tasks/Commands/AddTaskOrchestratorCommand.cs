using MediatR;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Commands
{
    public record AddTaskOrchestratorCommand(AddTaskDTO AddTaskDTO):IRequest<ResponseViewModel>;
    
    public class AddTaskOrchestratorCommandHandler : IRequestHandler<AddTaskOrchestratorCommand, ResponseViewModel>
    {
        IMediator _mediator;
        public AddTaskOrchestratorCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseViewModel> Handle(AddTaskOrchestratorCommand request, CancellationToken cancellationToken)
        {
            TaskDTO taskdto = request.AddTaskDTO.MapOne<TaskDTO>();
           var task =await _mediator.Send(new AddTaskCommand(taskdto));

            if(task == null)
            {
                return ResponseViewModel.Faliure("Task not Added correctly");
            }
            UserTaskDTO userTaskDTO = new UserTaskDTO();
            userTaskDTO.TaskId = task.Id;
            userTaskDTO.UserId = request.AddTaskDTO.UserId;

            var userTask = await _mediator.Send( new AssignUserInTaskCommand(userTaskDTO));

            TaskProjectDTO projectDTO = new TaskProjectDTO();
            projectDTO.TaskId = task.Id;
            projectDTO.ProjectId = request.AddTaskDTO.ProjectId;
            var projectTask = await _mediator.Send(new AssignTaskInProjectCommand(projectDTO));

            return ResponseViewModel.Success(task);

        }
    }
}
