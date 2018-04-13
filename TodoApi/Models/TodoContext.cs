using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
