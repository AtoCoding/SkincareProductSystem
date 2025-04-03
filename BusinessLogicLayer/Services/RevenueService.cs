using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.Bases;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Bases;

namespace BusinessLogicLayer.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _repository = new RevenueRepository();

        public List<object> GetRevenueList()
        {
            return _repository.GetRevenueList();
        }

        public List<int> GetStatistical()
        {
            List<int> list = new List<int>();
            list.Add(_repository.GetTotalNewUsers());
            list.Add(_repository.GetTotalBuyers());
            list.Add(_repository.GetTotalProductsSold());
            list.Add(_repository.GetTotalOrders());

            return list;
        }

        public List<ProductDto> GetTopProductsSold()
        {
            return _repository.GetTopProductsSold();
        }

        public List<ProductDto> GetLowSalesProducts()
        {
            return _repository.GetLowSalesProducts();
        }

        public List<ProductDto> GetTopProductsInMonth()
        {
            return _repository.GetTopProductsInMonth();
        }
    }
}
