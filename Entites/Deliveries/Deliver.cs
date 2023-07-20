using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Deliveries;

public class Deliver : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordConfirmed { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

}
