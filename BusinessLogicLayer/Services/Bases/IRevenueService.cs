using BusinessLogicLayer.Dtos;

namespace BusinessLogicLayer.Services.Bases
{
    public interface IRevenueService
    {
        List<object> GetRevenueList();
        List<int> GetStatistical();
        List<ProductDto> GetTopProductsSold();
        List<ProductDto> GetLowSalesProducts();
        List<ProductDto> GetTopProductsInMonth();
    }
}
