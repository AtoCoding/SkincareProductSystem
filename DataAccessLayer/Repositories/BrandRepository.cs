using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private static BrandRepository _Instance = null!;

        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private BrandRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static BrandRepository GetInstance() => _Instance ??= new BrandRepository();

        public bool Add(Brand data)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Brand? Get(int id)
        {
            return null;
        }

        public List<Brand> GetAll()
        {
            return _SkincareProductSystemContext.Brands.ToList();
        }

        public List<Brand> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Brand data)
        {
            return false;
        }
    }
}
