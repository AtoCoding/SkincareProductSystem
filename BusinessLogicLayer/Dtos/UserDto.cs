namespace BusinessLogicLayer.Dtos;

public class UserDto
{
    public string Username { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int RoleId { get; set; }
}
