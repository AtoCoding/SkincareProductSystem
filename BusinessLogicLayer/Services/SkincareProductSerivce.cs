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
