using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public BrandRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public Brand Add(Brand data)
        {
            return null!;
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
            return [];
        }

        public Brand? Update(Brand data)
        {
            return null;
        }
    }
}
