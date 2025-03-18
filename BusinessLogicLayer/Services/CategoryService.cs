using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : IService<CategoryDto>
    {
        private static CategoryService _Instance = null!;
        private readonly IRepository<Category> _CategoryRepository;

        private CategoryService()
        {
            _CategoryRepository = CategoryRepository.GetInstance();
        }

        public static CategoryService GetInstance() => _Instance ??= new CategoryService();

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

        public List<CategoryDto> Search(string? keyword)
        {
            return [];
        }

        public CategoryDto? Update(CategoryDto data)
        {
            return null;
        }
    }
}
