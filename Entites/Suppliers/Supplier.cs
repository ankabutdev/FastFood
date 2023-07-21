using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Suppliers;

public class Supplier : Auditable
{
    [MaxLength(50)]
    public string CompanyName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [MaxLength(13)]
    public string ContactPhoneNumber { get; set; } = string.Empty;

}
