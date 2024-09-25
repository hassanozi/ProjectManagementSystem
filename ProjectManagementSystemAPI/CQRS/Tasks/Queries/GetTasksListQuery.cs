using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Queries
{
    public class GetTasksListQuery : IRequest<IEnumerable<TaskDTO>>
    {

    }

    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, IEnumerable<TaskDTO>>
    {
        private readonly IRepository<Task> _repo;

        public GetTasksListQueryHandler(IRepository<Task> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskDTO>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var Tasks = await _repo.GetAll().ToListAsync();

            return Tasks.Select(x => x.MapOne<TaskDTO>());
        }
    }
}
