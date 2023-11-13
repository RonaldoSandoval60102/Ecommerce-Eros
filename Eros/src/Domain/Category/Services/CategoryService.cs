using Eros.src.Domain.Category.Repository;

namespace Eros.src.Domain.Category.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            _categoryRepository = repository;
        }

        public async Task<Models.Category> Create(Models.Category entity)
        {
            return await _categoryRepository.Create(entity);
        }

        public void Delete(Models.Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public async Task<List<Models.Category>> Get()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Models.Category?> Get(long id)
        {
            return await _categoryRepository.Get(id);
        }

        public async Task<Models.Category> Update(Models.Category entity)
        {
            return await _categoryRepository.Update(entity);
        }
    }
}