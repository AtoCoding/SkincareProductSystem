namespace DataAccessLayer.Entities;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int SkincareProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual SkincareProduct SkincareProduct { get; set; } = null!;
}
