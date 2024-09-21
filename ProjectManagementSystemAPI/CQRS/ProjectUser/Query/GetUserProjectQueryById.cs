using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.ProjectUser.Query
{
    public record GetUserProjectQueryById(UserProjectDTO UserProjectDTO) : IRequest<UserProject>;

    public class GetUserProjectQueryHandler : BaseRequestHandler<UserProject, GetUserProjectQueryById, UserProject>
    {
        public GetUserProjectQueryHandler(RequestParameters requestParameters, IRepository<UserProject> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<UserProject> Handle(GetUserProjectQueryById request, CancellationToken cancellationToken)
        {
           if(request == null || 
                request.UserProjectDTO.ProjectId == 0 ||
                request.UserProjectDTO.UserId == 0)
           {
                return null;

           }

           var result =  _repository.Get(u=>
           u.ProjectId == request.UserProjectDTO.ProjectId &&
           u.UserId == request.UserProjectDTO.UserId).FirstOrDefault();
            if(result == null)
            {
               return null;
            }
            return (result);
       
        }
    }
}
