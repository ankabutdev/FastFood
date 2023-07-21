using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Entites;

public abstract class Human : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(9)]
    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Country { get; set; } = String.Empty;

    public string Region { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
