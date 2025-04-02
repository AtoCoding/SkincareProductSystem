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

        public bool Add(Category data)
        {
            return false;
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
            return _CategoryRepository.GetAll();
        }

        public List<Category> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Category data)
        {
            return false;
        }
    }
}
