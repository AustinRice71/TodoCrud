namespace TodoCrud.Services
{
    public interface IService<T>
    {
        public T Create(string data);
        public T Update(T data);
        public T Delete(Guid id);
        public T Get(Guid id);
        public List<T> GetAll();
    }
}
