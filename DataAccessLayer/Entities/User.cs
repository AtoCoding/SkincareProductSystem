namespace DataAccessLayer.Entities;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public bool IsActive { get; set; }

    public int RoleId { get; set; }

    public int TypeOfSkinId { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SkincareProduct> SkincareProducts { get; set; } = new List<SkincareProduct>();

    public virtual TypeOfSkin TypeOfSkin { get; set; } = null!;
}
