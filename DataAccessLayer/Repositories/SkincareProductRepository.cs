using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class SkincareProductRepository : IRepository<SkincareProduct>
    {
        private static SkincareProductRepository _Instance = null!;
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private SkincareProductRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static SkincareProductRepository GetInstance() => _Instance ??= new SkincareProductRepository();

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

        public List<SkincareProduct> Search(string? keyword)
        {
            return [];
        }

        public SkincareProduct? Update(SkincareProduct data)
        {
            return null;
        }
    }
}
