namespace FastFood.Entites.Orders;

public class OrderDetails : Auditable
{
    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    // Price prices of the products
    // Product price * quantity

    public double TotalPrice { get; set; }

    public double DiscountPrice { get; set; }

    // Prices that user must pay for these products
    // TotalPrice - DiscountPrice

    public double ResultPrice { get; set; }
}
