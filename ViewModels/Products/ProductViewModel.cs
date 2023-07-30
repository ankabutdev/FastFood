using FastFood.Entites;

namespace FastFood.ViewModels.Products;

public class ProductViewModel : Auditable
{

    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public long Quantity { get; set; }

    public double UnitPrice { get; set; }

    public short Discount { get; set; }

    public string Description { get; set; } = string.Empty;

    public long CategoryId { get; set; }

    public long CompanyId { get; set; }

}
