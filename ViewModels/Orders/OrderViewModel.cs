using FastFood.Entites;
using FastFood.Entites.Orders;
using FastFood.Enums;

namespace FastFood.ViewModels.Orders;

public class OrderViewModel : Auditable
{
    public Order? Order { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public PaymentType PaymentType { get; set; }

}
