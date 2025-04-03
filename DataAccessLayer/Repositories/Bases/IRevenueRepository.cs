using BusinessLogicLayer.Dtos;

namespace DataAccessLayer.Repositories.Bases
{
    public interface IRevenueRepository
    {
        List<object> GetRevenueList();
        int GetTotalNewUsers();
        int GetTotalBuyers();
        int GetTotalProductsSold();
        int GetTotalOrders();
        List<ProductDto> GetTopProductsSold();
        List<ProductDto> GetLowSalesProducts();
        List<ProductDto> GetTopProductsInMonth();
    }
}
