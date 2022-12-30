using Microsoft.AspNetCore.Mvc;
using TodoContracts.Models;
using TodoCrud.Services;

namespace TodoCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private TodoService _Service = new TodoService();

        [HttpGet("get-all")]
        public IEnumerable<Todo> GetAll()
        {
            return _Service.GetTodos();
        }

        [HttpGet("get-one/{id}")]
        public Todo Get(Guid id)
        {
            return _Service.Get(id);
        }

        [HttpPost("create")]
        public Todo Create(String name)
        {
            return _Service.CreateTodo(name);
        }

        [HttpPut("update")]
        public void Update(Todo todo)
        {
            _Service.UpdateTodo(todo);
        }

        [HttpPut("toggle-complete/{id}")]
        public void ToggleComplete(Guid id)
        {
            _Service.ToggleComplete(id);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(Guid id)
        {
            _Service.Delete(id);

        }

        [HttpGet("view-todos")]
        public IActionResult ViewTodos()
        {
            string content = "<ul>";
            var todos = _Service.GetTodos();
            foreach (var todo in todos)
            {
                content += $"<li>{todo.Name} - {(todo.Complete ? "✔" : "")}</li>";
            }
            content += "</ul>";

            return Content($"<html>{content}</html>", "text/html");
        }

    }
}
