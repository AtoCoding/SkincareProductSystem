using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Dtos;

public class RoleDto
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<UserDto>? Users { get; set; }
}
