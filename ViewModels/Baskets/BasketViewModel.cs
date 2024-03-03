using FastFood.Entites;
using FastFood.Enums;

namespace FastFood.ViewModels.Baskets;

public class BasketViewModel : Auditable
{
    public long UserId { get; set; }

    public long DeliveryId { get; set; }

    public long ProductId { get; set; }

    public OrderStatus Status { get; set; }

    // The summ of order details result prices
    // The monay which that user must pay for products
    public double ProductsPrice { get; set; }

    public double DeliveryPrice { get; set; }

    // The payment that user must pay for sales
    // Products Price + Delivery Price
    public double ResultPrice { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public PaymentType PaymentType { get; set; }

    public bool IsPaid { get; set; }

    public string Description { get; set; } = string.Empty;

    public long OrderId { get; set; }

    public long Quantity { get; set; }

    // Price prices of the products
    // Product price * quantity
    public double TotalPrice { get; set; }

    public double DiscountPrice { get; set; }

}
