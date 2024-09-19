using MediatR;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Paging;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Repositories.User;
using ProjectManagementSystemAPI.ViewModels.Auth;
using ProjectManagementSystemAPI.ViewModels.UserViewModels;

namespace ProjectManagementSystemAPI.CQRS.User.Queries
{
    public record GetAllUsersQuery(PagingParameters PagingParameters) : IRequest<PagedList<IEnumerable<UserReturnDto>>>;

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedList< IEnumerable<UserReturnDto>>>
    {
         IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<PagedList<IEnumerable<UserReturnDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAllUsers( request.PagingParameters).MapOne< PagedList<IEnumerable<UserReturnDto>>>();
            return users;
        }
    }
}
