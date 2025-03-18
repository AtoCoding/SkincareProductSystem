using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IService<Order>
    {
        private static OrderService _Instance = null!;
        private readonly OrderRepository _OrderRepository;

        private OrderService()
        {
            _OrderRepository = OrderRepository.GetInstance();
        }

        public static OrderService GetInstance() => _Instance ??= new OrderService();

        public Order Add(Order data)
        {
            return null!;
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
