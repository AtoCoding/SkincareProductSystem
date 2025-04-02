using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class SkincareProductService : IService<SkincareProduct>
    {
        private static SkincareProductService _Instance = null!;
        private readonly IRepository<SkincareProduct> _SkincareProductRepository;

        private SkincareProductService()
        {
            _SkincareProductRepository = SkincareProductRepository.GetInstance();
        }

        public static SkincareProductService GetInstance() => _Instance ??= new SkincareProductService();

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
            return _SkincareProductRepository.GetAll();
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
