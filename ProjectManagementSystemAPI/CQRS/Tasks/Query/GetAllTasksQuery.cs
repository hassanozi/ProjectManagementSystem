using MediatR;
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
            

            var tasks = _repository.GetAllPag(x=>x.Title == request.TaskDTO.Title && x.ProjectId == request.TaskDTO.ProjectId, 3,0,x=>x.Project,x=>x.UserTasks)
                .Result.Select(x=> new TaskAllDataDTO
            {
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                ProjectName = x.Project.Title,
                // Get the latest User based on a date field, e.g., JoinDate or StartDate
                UserName = x.UserTasks.OrderByDescending(ut=>ut.User.CreateDate)
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
