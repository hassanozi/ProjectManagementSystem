using MediatR;
using ProjectManagementSystemAPI.DTO.Project;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Projects.Commands
{
    public record AddProjectCommand(AddProjectDTO AddProjectDTO) :IRequest<ResponseViewModel>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, ResponseViewModel>
    {
        IRepository<Project> _repository;
        public AddProjectCommandHandler(IRepository<Project> repository) 
        {
        
        _repository = repository;
        }

        public async Task<ResponseViewModel> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return default;
            }

            var project = request.AddProjectDTO.MapOne<Project>();
            project = await _repository.AddAsync(project);

            return ResponseViewModel.Sucess(project);
            
           
        }
    }
}
