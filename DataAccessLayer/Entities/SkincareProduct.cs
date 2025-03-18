namespace DataAccessLayer.Entities;

public partial class SkincareProduct
{
    public int SkincareProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Capacity { get; set; }

    public decimal UnitPrice { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    public string Username { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual User UsernameNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
