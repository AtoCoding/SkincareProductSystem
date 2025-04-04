using DataAccessLayer.DTOs;

namespace BusinessLogicLayer.Services.Bases
{
    public interface IRevenueService
    {
        List<object> GetRevenueList();
        List<int> GetStatistical();
        List<ProductDTO> GetTopProductsSold();
        List<ProductDTO> GetLowSalesProducts();
        List<ProductDTO> GetTopProductsInMonth();
    }
}
