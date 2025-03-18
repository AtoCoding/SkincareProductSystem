using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private static OrderRepository _Instance = null!;
        private readonly SkincareProductSystemContext __SkincareProductSystemContext;

        private OrderRepository()
        {
            __SkincareProductSystemContext = new();
        }

        public static OrderRepository GetInstance() => _Instance ??= new OrderRepository();

        public Order Add(Order data)
        {
            return data;
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
            return [];
        }

        public List<Order> Search(string? keyword)
        {
            return [];
        }

        public Order? Update(Order data)
        {
            return null!;
        }
    }
}
