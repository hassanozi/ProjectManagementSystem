using MediatR;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Models;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Commands
{
    public record AssignTaskInProjectCommand(TaskProjectDTO TaskProjectDTO):IRequest<ProjectTask>;
   
    public class AssignTaskInProjectCommandHandler : IRequestHandler<AssignTaskInProjectCommand, ProjectTask>
    {
        IRepository<ProjectTask> _repository;
        public AssignTaskInProjectCommandHandler(IRepository<ProjectTask> repository)
        {
            _repository = repository;
        }

        public async Task<ProjectTask> Handle(AssignTaskInProjectCommand request, CancellationToken cancellationToken)
        {
            var projectTask = request.TaskProjectDTO.MapOne<ProjectTask>();
            projectTask = await _repository.AddAsync(projectTask);
            return projectTask;
            
        }
    }


}
