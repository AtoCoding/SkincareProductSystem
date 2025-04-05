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
            _SkincareProductSystemContext.SkincareProducts.Add(data);

            return _SkincareProductSystemContext.SaveChanges() > 0;
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
            return _SkincareProductSystemContext.SkincareProducts.FirstOrDefault(x => x.SkincareProductId == id);
        }

        public List<SkincareProduct> GetAll()
        {
            return _SkincareProductSystemContext.SkincareProducts.Include(x => x.Category)
                                                                 .Include(x => x.Brand)
                                                                 .ToList();
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
                           (x.Brand != null && x.Brand.Name.ToLower().Trim().Contains(normalizedKeyword)) ||
                           (!string.IsNullOrEmpty(x.Description) && x.Description.ToLower().Trim().Contains(normalizedKeyword)))
                .ToList();
        }

        public bool Update(SkincareProduct data)
        {
            return _SkincareProductSystemContext.SaveChanges() > 0;
        }

        // Product management respository
        //public List<SkincareProduct> GetAllWithBrandAndCategory()
        //{
        //    return _SkincareProductSystemContext.SkincareProducts.Include(x => x.Brand).Include(x => x.Category).ToList();
        //}
    }
}
