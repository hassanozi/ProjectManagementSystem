using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.DTOs.TaskDTOs
{
    public class TaskAllDataDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StatusTask Status { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }

    }
}
