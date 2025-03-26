using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : IService<Category>
    {
        private static CategoryService _Instance = null!;
        private readonly IRepository<Category> _CategoryRepository;

        private CategoryService()
        {
            _CategoryRepository = CategoryRepository.GetInstance();
        }

        public static CategoryService GetInstance() => _Instance ??= new CategoryService();

        public Category Add(Category data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Category? Get(int id)
        {
            return null;
        }

        public List<Category> GetAll()
        {
            return [];
        }

        public List<Category> Search(string? keyword)
        {
            return [];
        }

        public Category? Update(Category data)
        {
            return null;
        }
    }
}
