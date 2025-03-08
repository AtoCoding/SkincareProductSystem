namespace DataAccessLayer.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public bool IsAvailable { get; set; }

    public string Username { get; set; } = null!;

    public virtual ICollection<SkincareProduct> SkincareProducts { get; set; } = new List<SkincareProduct>();

    public virtual User UsernameNavigation { get; set; } = null!;
}
