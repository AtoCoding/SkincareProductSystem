using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class BrandService : IService<BrandDto>
    {
        private static BrandService _Instance = null!;
        private readonly IRepository<Brand> _BrandRepository;

        private BrandService()
        {
            _BrandRepository = BrandRepository.GetInstance();
        }

        public static BrandService GetInstance() => _Instance ??= new BrandService();

        public BrandDto Add(BrandDto data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public BrandDto? Get(int id)
        {
            return null;
        }

        public List<BrandDto> GetAll()
        {
            return [];
        }

        public List<BrandDto> Search(string? keyword)
        {
            return [];
        }

        public BrandDto? Update(BrandDto data)
        {
            return null;
        }
    }
}
