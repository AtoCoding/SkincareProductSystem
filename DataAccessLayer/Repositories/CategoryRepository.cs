using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private static CategoryRepository _Instance = null!;
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public CategoryRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static CategoryRepository GetInstance() => _Instance ??= new CategoryRepository();

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
