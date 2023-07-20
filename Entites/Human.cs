using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites;

public class Human : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public string IsMale { get; set; } = string.Empty;

}
