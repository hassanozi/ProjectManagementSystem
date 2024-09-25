using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.Constants;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Specification;
using ProjectManagementSystemAPI.ViewModels;
using System.Linq;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Query
{
    public record GetAllTasksQuery(TaskDTO TaskDTO) :IRequest<ResponseViewModel>;

    public class GetAllTasksQueryHandler : BaseRequestHandler<Model.Tasks, GetAllTasksQuery, ResponseViewModel>
    {
        public GetAllTasksQueryHandler(RequestParameters requestParameters, IRepository<Model.Tasks> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<ResponseViewModel> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            BaseSpecification<Model.Tasks> baseSpecification = new BaseSpecification<Model.Tasks>();
            baseSpecification.AddInclude(t => t.Include(p => p.Project));
            baseSpecification.AddInclude(t => t.Include(u => u.UserTasks));

            var tasks = _repository.GetAll(baseSpecification)
                .Result.Select(x=> new TaskAllDataDTO
            {
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                ProjectName = x.Project.Title,
                // Get the latest User based on a date field, e.g., JoinDate or StartDate
                UserName = x.UserTasks
                           .Select(ut => ut.User.UserName)
                           .SingleOrDefault()
                           ,
                EndDate = x.EndDate,
            });

           var result = tasks.ToList();
            return ResponseViewModel.Success(result);
        }
    }


}
