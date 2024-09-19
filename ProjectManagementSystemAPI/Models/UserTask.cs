namespace ProjectManagementSystemAPI.Model
{
    public class UserTask : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
