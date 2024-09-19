using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.DTO.Projects;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Query
{
    public class GetProjectsListQuery : IRequest<IEnumerable<ProjectsDTO>>
    {

    }


    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, IEnumerable<ProjectsDTO>>
    {
        private readonly IRepository<Project> _repo;

        public GetProjectsListQueryHandler(IRepository<Project> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProjectsDTO>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repo.GetAll().ToListAsync();

            return projects.Select(x => x.MapOne<ProjectsDTO>());
            //return _mapper.Map<IEnumerable<ProjectsDTO>>(projects);


            //return _mapper.Map<IEnumerable<ProjectsDTO>>(projects);
        }
    }
}
