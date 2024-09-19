using AutoMapper;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Models;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class TaskProfile :Profile
    {
        public TaskProfile() 
        {
            CreateMap<AddTaskDTO,Model.Tasks>().ReverseMap();
            CreateMap<TaskDTO, Model.Tasks>().ReverseMap();
            CreateMap<TaskDTO, AddTaskDTO>().ReverseMap();
            CreateMap<UserTaskDTO, UserTask>().ReverseMap();
            CreateMap<ProjectTask, TaskProjectDTO>().ReverseMap();

        }

    }
}
