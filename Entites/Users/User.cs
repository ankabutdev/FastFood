using FastFood.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordConfirmed { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public IdentityRole Role { get; set; }
}
