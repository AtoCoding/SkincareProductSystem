using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class SkincareProductService : IService<SkincareProductDto>
    {
        private static SkincareProductService _Instance = null!;
        private readonly IRepository<SkincareProduct> _SkincareProductRepository;

        private SkincareProductService()
        {
            _SkincareProductRepository = SkincareProductRepository.GetInstance();
        }

        public static SkincareProductService GetInstance() => _Instance ??= new SkincareProductService();

        public SkincareProductDto Add(SkincareProductDto data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public SkincareProductDto? Get(int id)
        {
            return null;
        }

        public List<SkincareProductDto> GetAll()
        {
            return [];
        }

        public List<SkincareProductDto> Search(string? keyword)
        {
            return [];
        }

        public SkincareProductDto? Update(SkincareProductDto data)
        {
            return null;
        }
    }
}
