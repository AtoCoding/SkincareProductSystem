using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class SkincareProductService : IService<SkincareProductDto>
    {
        private readonly IRepository<SkincareProduct> _SkincareProductRepository;

        public SkincareProductService()
        {
            _SkincareProductRepository = new SkincareProductRepository();
        }

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

        public SkincareProductDto? Update(SkincareProductDto data)
        {
            return null;
        }
    }
}
