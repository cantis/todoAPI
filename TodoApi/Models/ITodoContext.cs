using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
    }
}