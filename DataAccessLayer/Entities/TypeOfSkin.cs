namespace DataAccessLayer.Entities;

public partial class TypeOfSkin
{
    public int TypeOfSkinId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
