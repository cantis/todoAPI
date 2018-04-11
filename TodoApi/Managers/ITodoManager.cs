using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Managers
{
    internal interface ITodoManager
    {
        List<TodoItem> GetAll();

        TodoItem GetById(int id);

        void Update(TodoItem item);

        void Delete(int id);
    }
}
