namespace ProjectManagementSystemAPI.DTOs.TaskDTOs
{
    public class AddTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }


    }
}

