using System.ComponentModel.DataAnnotations;

namespace todo_migration_app.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Todo> Todos { get; set; }
        }
}
