namespace todo_migration_app.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Description { get; set; } 
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }

        public User User { get; set; }
    }
}