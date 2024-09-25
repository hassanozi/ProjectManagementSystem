using MediatR;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Task.Commands
{
    public record AssignUserInTaskCommand(UserTaskDTO UserTaskDTO) : IRequest<UserTask>;
    
    public class AssignUserInTaskCommandHandler : IRequestHandler<AssignUserInTaskCommand, UserTask>
    {
        IRepository<UserTask> _repository;
        public AssignUserInTaskCommandHandler(IRepository<UserTask> repository)
        {
            _repository = repository;
        }

        public async Task<UserTask> Handle(AssignUserInTaskCommand request, CancellationToken cancellationToken)
        {
            var UserTask = request.UserTaskDTO.MapOne<UserTask>();
            

            UserTask = await _repository.AddAsync(UserTask);
           await  _repository.SaveChangesAsync();
            return UserTask;
            
        }
    }
}
