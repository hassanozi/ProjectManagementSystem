using AutoMapper;
using ProjectManagementSystemAPI.DTO.Projects;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels.Projects;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class ProjectsProfile : Profile
    {
        protected ProjectsProfile()
        {
            CreateMap<ProjectsDTO,Project>().ReverseMap();
            CreateMap<ProjectViewModel, ProjectsDTO>();
            CreateMap<ProjectsDTO , ProjectViewModel >();
        }
    }
}
