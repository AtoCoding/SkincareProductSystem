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
            return _SkincareProductRepository.Add(data);
        }

        public bool Delete(int id)
        {
            return _SkincareProductRepository.Delete(id);
        }

        public SkincareProduct? Get(int id)
        {
            return _SkincareProductRepository.Get(id);
        }

        public List<SkincareProduct> GetAll()
        {
            return _SkincareProductRepository.GetAll();
        }

        public List<SkincareProduct> Search(string? keyword)
        {
            return _SkincareProductRepository.Search(keyword);
        }

        public bool Update(SkincareProduct data)
        {
            SkincareProduct? product = _SkincareProductRepository.Get(data.SkincareProductId);

            if (product != null)
            {
                product.Name = data.Name;
                product.Description = data.Description;
                product.Capacity = data.Capacity;
                product.UnitPrice = data.UnitPrice;
                product.Quantity = data.Quantity;
                product.Image = Path.GetFileName(data.Image);
                product.IsAvailable = data.IsAvailable;
                product.CategoryId = data.CategoryId;
                product.BrandId = data.BrandId;

                return _SkincareProductRepository.Update(product);
            }

            return false;
        }
    }
}
