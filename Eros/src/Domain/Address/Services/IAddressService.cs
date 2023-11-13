namespace Eros.src.Domain.Address.Services
{
    public interface IAddressService
    {
        Task<List<Models.Address>> Get();
        Task<Models.Address?> Get(long id);
        Task<Models.Address> Create(Models.Address entity);
        Task<Models.Address> Update(Models.Address entity);
        void Delete(Models.Address entity);  
    }
}