using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Handle CRUD for To do items
    /// </summary>
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
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

        /// <summary>
        /// Add a new todo item
        /// </summary>
        /// <returns>List of todo items</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.TodoItems.ToList();

            return new ObjectResult(result);
        }

        /// <summary>
        /// Get a single Todo item
        /// </summary>
        /// <param name="id">Todo item id</param>
        /// <returns>Single Todo item</returns>
        /// <response code="404">Not found</response>
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Create a Todo Item
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <response code="201">Created</response>
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            // The created at route should return a link to the new item.
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        /// <summary>
        /// Update a Todo Item
        /// </summary>
        /// <param name="id">Id of item to update</param>
        /// <param name="item">The text of the todo</param>
        /// <returns>OK result</returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo==null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new OkResult();
        }

        /// <summary>
        /// Delete a Todo Item
        /// </summary>
        /// <param name="id">ID of item to delete</param>
        /// <returns>OK if successfull</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo==null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
