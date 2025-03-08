using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class SkincareProductRepository : IRepository<SkincareProduct>
    {
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public SkincareProductRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public SkincareProduct Add(SkincareProduct data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public SkincareProduct? Get(int id)
        {
            return null;
        }

        public List<SkincareProduct> GetAll()
        {
            return [];
        }

        public SkincareProduct? Update(SkincareProduct data)
        {
            return null;
        }
    }
}
