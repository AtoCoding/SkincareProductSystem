using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class SkincareProductRepository : IRepository<SkincareProduct>
    {
        private static SkincareProductRepository _Instance = null!;
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private SkincareProductRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static SkincareProductRepository GetInstance() => _Instance ??= new SkincareProductRepository();

        public bool Add(SkincareProduct data)
        {
            if( _SkincareProductSystemContext.SkincareProducts.Add(data) != null)
                _SkincareProductSystemContext.SaveChanges();
               return true
            ;
        }

        public bool Delete(int id)
        {
           if (_SkincareProductSystemContext.SkincareProducts.Remove(_SkincareProductSystemContext.SkincareProducts.Find(id)) != null)
                _SkincareProductSystemContext.SaveChanges();
            return true
         ;
        }

        public SkincareProduct? Get(int id)
        {
            return null;
        }

        public List<SkincareProduct> GetAll()
        {
            return _SkincareProductSystemContext.SkincareProducts.Include(x => x.Brand).Include(x => x.Category).ToList();
        }

        public List<SkincareProduct> Search(string? keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _SkincareProductSystemContext.SkincareProducts.ToList(); // Trả về tất cả sản phẩm nếu keyword rỗng hoặc null
            }

            string normalizedKeyword = keyword.ToLower().Trim();

            return _SkincareProductSystemContext.SkincareProducts
                .Where(x => x.Name.ToLower().Trim().Contains(normalizedKeyword) ||
                            (x.Brand != null && x.Brand.Name.ToLower().Trim().Contains(normalizedKeyword)))
                .ToList();
        }

        public bool Update(SkincareProduct data)
        {
            try
            {
                var skincareProduct = _SkincareProductSystemContext.SkincareProducts.FirstOrDefault(x => x.SkincareProductId == data.SkincareProductId);
                if (skincareProduct == null) 
                    return false;
                skincareProduct.Name = data.Name;
                    skincareProduct.Description = data.Description;
                    skincareProduct.Capacity = data.Capacity;
                    skincareProduct.UnitPrice = data.UnitPrice;
                    skincareProduct.Quantity = data.Quantity;
                    skincareProduct.Image = data.Image;
                    skincareProduct.IsAvailable = data.IsAvailable;
                    skincareProduct.CategoryId = data.CategoryId;
                    skincareProduct.BrandId = data.BrandId;
                    skincareProduct.Username = data.Username;
                    _SkincareProductSystemContext.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Product management respository
        //public List<SkincareProduct> GetAllWithBrandAndCategory()
        //{
        //    return _SkincareProductSystemContext.SkincareProducts.Include(x => x.Brand).Include(x => x.Category).ToList();
        //}
    }
}
