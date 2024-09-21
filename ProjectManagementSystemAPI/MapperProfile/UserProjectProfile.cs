using AutoMapper;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class UserProjectProfile:Profile
    {
        public UserProjectProfile() 
        {
            CreateMap<UserProject, UserProjectDTO>().ReverseMap();
            CreateMap<AddTaskDTO, UserProjectDTO>().ReverseMap();
        }

    }
}
