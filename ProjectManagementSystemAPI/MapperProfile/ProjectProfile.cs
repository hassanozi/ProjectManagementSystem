using AutoMapper;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels.ProjectViewModels;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<AddProjectDTO, Project>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                        .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                        .ForMember(dest => dest.UserProjects, opt => opt.Ignore());
            CreateMap<AddProjectViewModel, AddProjectDTO>();

            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
        }
    }
}
