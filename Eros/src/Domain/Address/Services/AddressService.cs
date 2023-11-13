using Eros.src.Domain.Address.Repository;

namespace Eros.src.Domain.Address.Services
{
    public class AddressService : IAddressService
    {     
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Models.Address> Create(Models.Address entity)
        {
            return await _addressRepository.Create(entity);
        }

        public void Delete(Models.Address entity)
        {
            _addressRepository.Delete(entity);
        }

        public async Task<List<Models.Address>> Get()
        {
            return await _addressRepository.Get();
        }

        public async Task<Models.Address?> Get(long id)
        {
            return await _addressRepository.Get(id);
        }

        public async Task<Models.Address> Update(Models.Address entity)
        {
            return await _addressRepository.Update(entity);
        }
    }
}