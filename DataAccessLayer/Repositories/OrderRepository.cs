using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private static OrderRepository _Instance = null!;

        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private OrderRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static OrderRepository GetInstance() => _Instance ??= new OrderRepository();

        public bool Add(Order data)
        {
            _SkincareProductSystemContext.Orders.Add(data);

            return _SkincareProductSystemContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Order? Get(int id)
        {
            return null!;
        }

        public List<Order> GetAll()
        {
            return _SkincareProductSystemContext.Orders.Include(x => x.OrderDetails)
                                                            .ThenInclude(x => x.SkincareProduct)
                                                       .ToList();
        }

        public List<Order> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Order data)
        {
            _SkincareProductSystemContext.Orders.Update(data);

            return _SkincareProductSystemContext.SaveChanges() > 0;
        }
    }
}
