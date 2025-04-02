namespace DataAccessLayer.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly DateCreated { get; set; }

    public string Username { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User UsernameNavigation { get; set; } = null!;
}
