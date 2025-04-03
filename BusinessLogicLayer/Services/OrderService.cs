using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IService<Order>
    {
        private static OrderService _Instance = null!;

        private readonly IUser _UserService;

        private readonly IService<SkincareProduct> _SkincareProductService;

        private readonly IRepository<Order> _OrderRepository;

        private OrderService()
        {
            _OrderRepository = OrderRepository.GetInstance();
            _UserService = UserService.GetInstance();
            _SkincareProductService = SkincareProductService.GetInstance();
        }

        public static OrderService GetInstance() => _Instance ??= new OrderService();

        public bool Add(Order data)
        {
            decimal totalPrice = 0;
            List<SkincareProduct> products = _SkincareProductService.GetAll();
            User? user = _UserService.GetByUserName(data.Username);

            foreach (OrderDetail orderDetail in data.OrderDetails)
            {
                totalPrice += orderDetail.TotalPrice;
            }

            if (user != null && user.Budget >= totalPrice)
            {
                foreach (OrderDetail orderDetail in data.OrderDetails)
                {
                    SkincareProduct? product = products.FirstOrDefault(p => p.SkincareProductId == orderDetail.SkincareProductId);
                    if (product != null && product.Quantity >= orderDetail.Quantity)
                    {
                        product.Quantity -= orderDetail.Quantity;
                        if (product.Quantity == 0)
                        {
                            product.IsAvailable = false;
                        }
                        if (!_SkincareProductService.Update(product)) break;
                    }
                }
                user.Budget -= totalPrice;
                if (_UserService.Update(user))
                {
                    return _OrderRepository.Add(data);
                }
            }
            return false;
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
            return _OrderRepository.GetAll();
        }

        public List<Order> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Order data)
        {
            return false;
        }
    }
}
