namespace Eros.src.Domain.User.Services
{
    public interface IUserService
    {
        Task<List<Models.User>> Get();
        Task<Models.User?> Get(long id);
        Task<Models.User> Create(Models.User entity);
        Task<Models.User> Update(Models.User entity);
        void Delete(Models.User entity);
    }
}