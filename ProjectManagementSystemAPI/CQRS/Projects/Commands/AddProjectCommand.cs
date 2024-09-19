using MediatR;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Commands
{
    public record AddProjectCommand(AddProjectDTO AddProjectDTO) : IRequest<bool>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, bool>
    {
        private readonly IRepository<Project> _repository;

        public AddProjectCommandHandler(IRepository<Project> repository) 
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.AddProjectDTO.MapOne<Project>();
            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
