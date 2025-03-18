namespace DataAccessLayer.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly DateCreated { get; set; }

    public string Username { get; set; } = null!;

    public virtual User UsernameNavigation { get; set; } = null!;

    public virtual ICollection<SkincareProduct> SkincareProducts { get; set; } = new List<SkincareProduct>();
}
