using System.ComponentModel;

namespace TodoApi.Models
{
    /// <summary>
    /// Represents a TodoItem
    /// </summary>
    public class TodoItem
    {
        [Description("ID of the Todo Item.") ]
        public long Id { get; set; }
        [Description("ToDo name - the text displayed.")]
        public string Name { get; set; }
        [Description("Is this ToDo Complete?")]
        public bool IsComplete { get; set; }
    }
}
