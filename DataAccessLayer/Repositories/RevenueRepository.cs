using BusinessLogicLayer.Dtos;
using DataAccessLayer.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly SkincareProductSystemContext _context = new();

        private DateOnly _firstDate;
        private DateOnly _endDate;
        private int _topN = 3;
        public RevenueRepository()
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            _firstDate = DateOnly.FromDateTime(new DateTime(now.Year, now.Month, 1));
            _endDate = DateOnly.FromDateTime(new DateTime(_firstDate.Year, _firstDate.Month, DateTime.DaysInMonth(_firstDate.Year, _firstDate.Month)));
        }

        public List<object> GetRevenueList()
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            var revenue = new List<object>();

            for (int i = 0; i < 3; i++)
            {
                DateOnly firstDate = DateOnly.FromDateTime(new DateTime(now.Year, now.Month, 1).AddMonths(-i));
                DateOnly endDate = DateOnly.FromDateTime(new DateTime(firstDate.Year, firstDate.Month, DateTime.DaysInMonth(firstDate.Year, firstDate.Month)));

                var result = _context.Orders
                .Where(o => o.DateCreated >= firstDate && o.DateCreated <= endDate)
                .SelectMany(o => o.OrderDetails)
                .Sum(od => od.TotalPrice);

                revenue.Add(new { Month = firstDate.ToString("MM/yyyy"), Revenue = result });
            }
            return revenue;
        }

        public int GetTotalNewUsers()
        {
            var result = _context.Users
                .Where(u => u.DateCreated >= _firstDate && u.DateCreated <= _endDate && u.RoleId == 3)
                .Count();
            return result;
        }

        public int GetTotalBuyers()
        {
            var result = _context.Orders
                .Where(o => o.DateCreated >= _firstDate && o.DateCreated <= _endDate)
                .Select(o => o.Username)
                .Distinct()
                .Count();
            return result;
        }

        public int GetTotalProductsSold()
        {
            var result = _context.Orders
                .Where(o => o.DateCreated >= _firstDate && o.DateCreated <= _endDate)
                .SelectMany(o => o.OrderDetails)
                .Sum(od => od.Quantity);
            return result;
        }

        public int GetTotalOrders()
        {
            var result = _context.Orders
                .Where(o => o.DateCreated >= _firstDate && o.DateCreated <= _endDate)
                .Count();
            return result;
        }

        public List<ProductDto> GetTopProductsSold()
        {
            var result = _context.OrderDetails
                .GroupBy(od => od.SkincareProductId)
                .Select(g => new
                {
                    SkincareProductId = g.Key,
                    TotalQuantity = g.Sum(od => od.Quantity)
                })
                .OrderByDescending(od => od.TotalQuantity)
                .Take(_topN)
                .Join(_context.SkincareProducts.AsNoTracking().Where(sp => sp.IsAvailable),
                t => t.SkincareProductId,
                sp => sp.SkincareProductId,
                (t, sp) => new { sp.Name, sp.UnitPrice, sp.BrandId, sp.CategoryId, sp.Image })
                .Join(_context.Brands.AsNoTracking(),
                x => x.BrandId,
                b => b.BrandId,
                (x, b) => new { x.Name, x.UnitPrice, BrandName = b.Name, x.CategoryId, x.Image })
                .Join(_context.Categories.AsNoTracking(),
                x => x.CategoryId,
                c => c.CategoryId,
                (x, c) => new ProductDto
                {
                    ProductName = x.Name ?? "Unknown",
                    ProductPrice = x.UnitPrice,
                    Brand = x.BrandName ?? "No Brand",
                    Category = c.Name ?? "No Category",
                    Image = x.Image ?? ""
                })
                .ToList();

            return result;
        }

        public List<ProductDto> GetLowSalesProducts()
        {
            var result = _context.SkincareProducts
                .Where(sp => sp.IsAvailable)
                .Include(sp => sp.Brand)
                .Include(sp => sp.Category)
                .GroupJoin(_context.OrderDetails,
                    sp => sp.SkincareProductId,
                    od => od.SkincareProductId,
                    (sp, orderDetails) => new
                    {
                        Product = sp,
                        TotalSold = orderDetails.Sum(od => (int?)od.Quantity) ?? 0
                    })
                .OrderBy(x => x.TotalSold)
                .Take(_topN)
                .Select(x => new ProductDto
                {
                    ProductName = x.Product.Name ?? "Unknown",
                    ProductPrice = x.Product.UnitPrice,
                    Brand = x.Product.Brand.Name ?? "No Brand",
                    Category = x.Product.Category.Name ?? "No Category",
                    Image = x.Product.Image ?? ""
                })
                .ToList();

            return result;
        }

        public List<ProductDto> GetTopProductsInMonth()
        {
            var result = _context.OrderDetails
                .Include(od => od.Order)
                .Where(od => od.Order.DateCreated >= _firstDate && od.Order.DateCreated <= _endDate)
                .Include(od => od.SkincareProduct)
                    .ThenInclude(sp => sp.Brand)
                .Include(od => od.SkincareProduct)
                    .ThenInclude(sp => sp.Category)
                .GroupBy(od => od.SkincareProduct)
                .Select(x => new
                {
                    Product = x.Key,
                    TotalSold = x.Sum(od => od.Quantity)
                })
                .Where(x => x.Product.IsAvailable)
                .OrderByDescending(x => x.TotalSold)
                .Take(_topN)
                .Select(x => new ProductDto
                {
                    ProductName = x.Product.Name ?? "Unknown",
                    ProductPrice = x.Product.UnitPrice,
                    Brand = x.Product.Brand.Name ?? "No Brand",
                    Category = x.Product.Category.Name ?? "No Category",
                    Image = x.Product.Image ?? "",
                })
                .ToList();
            return result;
        }
    }
}
