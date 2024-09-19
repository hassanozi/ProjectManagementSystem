using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.DTOs.ProjectDTOs
{
    public class AddProjectDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public StatusProject Status { get; set; }
    }
}
