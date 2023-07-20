namespace FastFood.Entites.Products;

public class ProductSupplier : Auditable
{
    public long ProductId { get; set; }

    public long SupplierId { get; set; }

    public long Quantity { get; set; }

    public long UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty;
}
