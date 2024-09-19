using MediatR;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Exceptions;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetProjectByIdQuery(int id) : IRequest<ProjectDTO>;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDTO>
    {
        private readonly IRepository<Project> _repository;
        public GetProjectByIdQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDTO> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.NotValidProjectID, "Invalid ProjectID!");
            }

            var project = _repository.GetByID(request.id).MapOne<ProjectDTO>();
            return project;
        }
    }
}
