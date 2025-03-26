using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class BrandService : IService<Brand>
    {
        private static BrandService _Instance = null!;
        private readonly IRepository<Brand> _BrandRepository;

        private BrandService()
        {
            _BrandRepository = BrandRepository.GetInstance();
        }

        public static BrandService GetInstance() => _Instance ??= new BrandService();

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

        public List<Brand> Search(string? keyword)
        {
            return [];
        }

        public Brand? Update(Brand data)
        {
            return null;
        }
    }
}
