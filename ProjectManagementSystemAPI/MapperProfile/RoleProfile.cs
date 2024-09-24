using AutoMapper;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.DTOs.RoleDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels.ProjectViewModels;
using ProjectManagementSystemAPI.ViewModels.RoleViewModel;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AddRoleDTO, Role>();
            CreateMap<AddRoleViewModel, AddRoleDTO>();

            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleDTO, RoleViewModel>().ReverseMap();
        }
    }
}
