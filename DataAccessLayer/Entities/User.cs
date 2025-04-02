using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public partial class User
{
    [Required(ErrorMessage = "Username is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters.")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
    public string Fullname { get; set; } = null!;

    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; } = null!;

    public decimal Budget { get; set; }

    public bool IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public int RoleId { get; set; }

    public int TypeOfSkinId { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SkincareProduct> SkincareProducts { get; set; } = new List<SkincareProduct>();

    public virtual TypeOfSkin TypeOfSkin { get; set; } = null!;
}
