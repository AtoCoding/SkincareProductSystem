namespace BusinessLogicLayer.Dtos;

public class SkincareProductDto
{
    public int SkincareProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int CategoryName { get; set; }

    public int BrandName { get; set; }

    public string Username { get; set; } = null!;
}
