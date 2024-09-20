using MediatR;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.DTOs.RoleDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Exceptions;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Roles.Query
{
    public record GetRoleByIdQuery(int id) : IRequest<RoleDTO>;
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDTO>
    {
        private readonly IRepository<Role> _repository;

        public GetRoleByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<RoleDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.NotValidRoleID, "Invalid RoleID!");
            }
            var role = _repository.GetByID(request.id).MapOne<RoleDTO>();
            return role;
        }
    }
}
