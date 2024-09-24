using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetProjectsListQuery : IRequest<IEnumerable<ProjectDTO>>;

    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, IEnumerable<ProjectDTO>>
    {
        private readonly IRepository<Project> _repository;

        public GetProjectsListQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProjectDTO>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAll().ToListAsync();
            var mappedProjects = projects.Select(x => x.MapOne<ProjectDTO>());
            return mappedProjects;
        }
    }
}
