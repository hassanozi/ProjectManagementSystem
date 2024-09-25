using MediatR;
using ProjectManagementSystemAPI.DTOs.RoleDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Exceptions;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Roles.Command
{
    public record CreateRoleCommand(AddRoleDTO addRoleDTO) : IRequest<Role>;

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly IRepository<Role> _repository;

        public CreateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if(request.addRoleDTO.Name ==  null)
            {
                throw new BusinessException(ErrorCode.NullName, "Name is required");

            }
            var role = request.addRoleDTO.MapOne<Role>();
            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();
            return role;    
        }
    }
}
