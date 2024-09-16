using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Project;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Commands
{
    public record AddProjectCommand(AddProjectDTO AddProjectDTO) :IRequest<ResultDTO>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, ResultDTO>
    {
        IRepository<Project> _repository;
        public AddProjectCommandHandler(IRepository<Project> repository) 
        {
        
        _repository = repository;
        }

        public async Task<ResultDTO> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return default;
            }

            var project = request.AddProjectDTO.MapOne<Project>();
            project = await _repository.AddAsync(project);

            return ResultDTO.Sucess(project);
            
           
        }
    }
}
