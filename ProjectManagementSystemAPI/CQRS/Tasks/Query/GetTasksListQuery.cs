using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Query
{
    public record GetTasksListQuery : IRequest<IEnumerable<TaskDTO>>;

    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, IEnumerable<TaskDTO>>
    {
        private readonly IRepository<Model.Tasks> _repository;

        public GetTasksListQueryHandler(IRepository<Model.Tasks> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskDTO>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var Tasks = await _repository.GetAll().ToListAsync();

            return Tasks.Select(x => x.MapOne<TaskDTO>());
        }
    }
}
