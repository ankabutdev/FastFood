using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Deliveries;

public class Deliver : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
}
