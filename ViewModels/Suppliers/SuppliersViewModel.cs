using FastFood.Entites;
using FastFood.Enums;
using System;

namespace FastFood.ViewModels.Suppliers;

public class SuppliersViewModel : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public PaymentType PaymentType { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }
}
