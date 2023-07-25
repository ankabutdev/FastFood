using FastFood.Entites;
using FastFood.Enums;

namespace FastFood.ViewModels.Deliveries;

public class DeliveryViewModel : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public PaymentType PaymentType { get; set; }

}
