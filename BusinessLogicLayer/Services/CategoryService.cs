using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : IService<CategoryDto>
    {
        private readonly IRepository<Category> _CategoryRepository;

        public CategoryService()
        {
            _CategoryRepository = new CategoryRepository();
        }

        public CategoryDto Add(CategoryDto data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public CategoryDto? Get(int id)
        {
            return null;
        }

        public List<CategoryDto> GetAll()
        {
            return [];
        }

        public CategoryDto? Update(CategoryDto data)
        {
            return null;
        }
    }
}
