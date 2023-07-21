namespace FastFood.Entites.Products;

public class ProductSupplier : Auditable
{
    public long ProductId { get; set; }

    public long SupplierId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty;
}
