using FastFood.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole Role { get; set; }
}
