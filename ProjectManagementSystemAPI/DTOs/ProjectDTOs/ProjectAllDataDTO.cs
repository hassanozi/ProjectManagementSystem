using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.DTOs.ProjectDTOs
{
    public class ProjectAllDataDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } 
        public StatusProject Status { get; set; }
        public int UsersNumber { get; set; }
        public int TasksNumber { get; set; }

    }
}
