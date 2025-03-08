using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class BrandService : IService<BrandDto>
    {
        private readonly IRepository<Brand> _BrandRepository;

        public BrandService()
        {
            _BrandRepository = new BrandRepository();
        }

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

        public BrandDto? Update(BrandDto data)
        {
            return null;
        }
    }
}
