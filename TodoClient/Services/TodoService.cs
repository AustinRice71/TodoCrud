using System.Net.Http.Json;
using TodoContracts.Models;


namespace TodoClient.Services
{

    public class TodoService
    {
        private HttpClient _HttpClient { get; set; }
        public TodoService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        //Get All
        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _HttpClient.GetFromJsonAsync<IEnumerable<Todo>>("Todo/get-all");
        }

        //TODO: Implement remaining API REQUESTS 

        public async Task<Todo> Get(Guid id)
        {
            return await _HttpClient.GetFromJsonAsync<Todo>($"Todo/get-one/{id}");
        }

        public async Task<Todo> Create(String name)
        {
            return await _HttpClient.GetFromJsonAsync<Todo>($"Todo/create");
        }

        public void Update(Todo todo)
        {
            _HttpClient.GetFromJsonAsync<Todo>($"Todo/update");
        }

        public void ToggleComplete(Guid id)
        {
            _HttpClient.GetFromJsonAsync<Todo>($"Todo/toggle-complete/{id}");
        }

        public void Delete(Guid id)
        {
            _HttpClient.GetFromJsonAsync<Todo>($"Todo/delete/{id}");

        }
    }
}
