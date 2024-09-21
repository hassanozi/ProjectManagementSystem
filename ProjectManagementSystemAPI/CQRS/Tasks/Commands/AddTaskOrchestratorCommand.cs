using MediatR;
using ProjectManagementSystemAPI.CQRS.ProjectUser.Query;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
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
            UserProjectDTO userProjectDTO = request.AddTaskDTO.MapOne<UserProjectDTO>();

            var UserProject = await _mediator.Send(new GetUserProjectQueryById( userProjectDTO));
            if(UserProject == null)
            {
                return ResponseViewModel.Faliure("this user not exist in the project");
            }
            
            //UserTaskDTO userTaskDTO = new UserTaskDTO();
            //userTaskDTO.TasksId = task.Id;
            //userTaskDTO.UserId = request.AddTaskDTO.UserId;

            //var userTask = await _mediator.Send( new AssignUserInTaskCommand(userTaskDTO));


           
            return ResponseViewModel.Success(task);

        }
    }
}
