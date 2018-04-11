using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Managers
{
    /// <summary>
    /// Defines the interface for the todo manager class
    /// </summary>
    public class TodoManager : ManagerBase, ITodoManager
    {

        private readonly TodoContext _context;

        public TodoManager(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Any()) return;

            _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            _context.TodoItems.Add(new TodoItem { Name = "Item2" });
            _context.TodoItems.Add(new TodoItem { Name = "Item3" });
            _context.TodoItems.Add(new TodoItem { Name = "Item4" });
            _context.TodoItems.Add(new TodoItem { Name = "Item5" });
            _context.TodoItems.Add(new TodoItem { Name = "Item6" });
            _context.TodoItems.Add(new TodoItem { Name = "Item7" });
            _context.TodoItems.Add(new TodoItem { Name = "Item8" });

            _context.SaveChanges();
        }

        public List<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
