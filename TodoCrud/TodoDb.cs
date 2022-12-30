using TodoContracts.Models;

namespace TodoCrud
{
    public static class TodoDb
    {
        public static Dictionary<Guid, Todo> Todos = new Dictionary<Guid, Todo>();

    }
}
