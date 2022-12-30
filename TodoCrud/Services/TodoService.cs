using System.Runtime.InteropServices;
using TodoContracts.Models;


namespace TodoCrud.Services
{
    public class TodoService
    {
        public Todo CreateTodo(string name)
        {
            var t = new Todo()
            {
                Name = name,
                Id = Guid.NewGuid(),
                Complete = false
            };
            TodoDb.Todos.Add(t.Id, t);
            return t;

        }

        //Get All (Read)
        public List<Todo> GetTodos()
        {
            return TodoDb.Todos.Values.ToList();
        }

        //Get by ID (Read)
        public Todo Get(Guid id)
        {
            return TodoDb.Todos.GetValueOrDefault(id) ?? new Todo();
        }

        //Update (Put)
        public void UpdateTodo(Todo todo)
        {
            if (TodoDb.Todos.TryGetValue(todo.Id, out var t))
            {
                t.Name = todo.Name;
                t.Complete = todo.Complete;
            }
        }

        //Delete (Delete)
        public void Delete(Guid id)
        {
            TodoDb.Todos.Remove(id);
        }

        //Toggle Complete
        public void ToggleComplete(Guid id)
        {
            //out assigns value from parameter method scope.
            if (TodoDb.Todos.TryGetValue(id, out var todo))
            {
                todo.Complete = !todo.Complete;
            }
        }
    }
}
