using BusinessLogicLayer.Services.Bases;
using DataAccessLayer.DTOs;
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

        public List<ProductDTO> GetTopProductsSold()
        {
            return _repository.GetTopProductsSold();
        }

        public List<ProductDTO> GetLowSalesProducts()
        {
            return _repository.GetLowSalesProducts();
        }

        public List<ProductDTO> GetTopProductsInMonth()
        {
            return _repository.GetTopProductsInMonth();
        }
    }
}
