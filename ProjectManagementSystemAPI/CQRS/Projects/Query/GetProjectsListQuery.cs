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
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(IRepository<Project> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectsDTO>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repo.GetAll().ToListAsync();

            return _mapper.Map<IEnumerable<ProjectsDTO>>(projects);


            //return _mapper.Map<IEnumerable<ProjectsDTO>>(projects);
        }
    }
}
