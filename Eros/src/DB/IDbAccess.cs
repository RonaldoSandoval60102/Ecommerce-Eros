namespace Eros.src.DB
{
    public interface IDbAccess<T> where T : class
    {
        Task<List<T>> Get();
        Task<T?> Get(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }
}