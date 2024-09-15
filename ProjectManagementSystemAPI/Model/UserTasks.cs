namespace ProjectManagementSystemAPI.Model
{
    public class UserTasks:BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }
    }
}
