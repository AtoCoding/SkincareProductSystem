using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Bases
{
    public interface IRevenueRepository
    {
        List<object> GetRevenueList();
        int GetTotalNewUsers();
        int GetTotalBuyers();
        int GetTotalProductsSold();
        int GetTotalOrders();
        List<ProductDTO> GetTopProductsSold();
        List<ProductDTO> GetLowSalesProducts();
        List<ProductDTO> GetTopProductsInMonth();

    }
}
