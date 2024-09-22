using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.DTOs.ProjectDTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public StatusProject Status { get; set; }
        //public List<Model.Task> Tasks { get; set; }
        //public List<User> Users { get; set; }
    }
}
