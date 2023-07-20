namespace FastFood.Entites.Products;

public class Product : Auditable
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long CategoryId { get; set; }

    public long UnitPrice { get; set; }

}
