using Microsoft.EntityFrameworkCore;
using todo_migration_app.Models;

namespace todo_migration_app
{
    public class TodoAppContext: DbContext
    {
        public TodoAppContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
       public DbSet<User> Users{ get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Todo>()
                .HasOne(t=>t.User)
                .WithMany(u=>u.Todos)
                .HasForeignKey(u=>u.Username)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);


        }
    }
}
