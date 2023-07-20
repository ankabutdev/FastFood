using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites.Discounts;

public class Discount : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public short Percentage { get; set; }
}
