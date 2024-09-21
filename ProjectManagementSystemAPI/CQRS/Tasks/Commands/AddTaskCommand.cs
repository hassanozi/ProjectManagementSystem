using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Commands
{
    public record AddTaskCommand(TaskDTO AddTaskDTO) : IRequest<Model.Tasks>;

    public class AddTaskCommandHandler : BaseRequestHandler<Model.Tasks,AddTaskCommand, Model.Tasks>
    {
       // IRepository<Model.Tasks> _repository;
        public AddTaskCommandHandler(RequestParameters requestParameters,IRepository<Model.Tasks> repository)
            : base( requestParameters, repository)
        {
            
        }

        //public async Task<Model.Tasks> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        //{
           

        //    Model.Tasks task = request.AddTaskDTO.MapOne<Model.Tasks>();

        //    var Task = await _repository.AddAsync(task);
        //    await _repository.SaveChangesAsync();

        //    return Task;

            
        //}

        public override async Task<Model.Tasks> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            Model.Tasks task = request.AddTaskDTO.MapOne<Model.Tasks>();

            var Task = await _repository.AddAsync(task);
            await _repository.SaveChangesAsync();

            return Task;

        }
    }
}
