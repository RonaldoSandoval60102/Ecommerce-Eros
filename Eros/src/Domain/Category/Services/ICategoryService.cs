namespace Eros.src.Domain.Category.Services
{
    public interface ICategoryService
    {
        Task<List<Models.Category>> Get();
        Task<Models.Category?> Get(long id);
        Task<Models.Category> Create(Models.Category entity);
        Task<Models.Category> Update(Models.Category entity);
        void Delete(Models.Category entity);
    }
}