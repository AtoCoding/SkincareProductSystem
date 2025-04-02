using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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

        public bool Add(SkincareProduct data)
        {
            return false;
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
            return _SkincareProductSystemContext.SkincareProducts.Include(x => x.Category)
                                                                 .Include(x => x.Brand)
                                                                 .ToList();
        }

        public List<SkincareProduct> Search(string? keyword)
        {
            return [];
        }

        public bool Update(SkincareProduct data)
        {
            return false;
        }
    }
}
