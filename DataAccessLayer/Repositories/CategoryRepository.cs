using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public CategoryRepository()
        {
            _SkincareProductSystemContext = new();
        }

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

        public Category? Update(Category data)
        {
            return null;
        }
    }
}
