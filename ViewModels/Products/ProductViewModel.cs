using FastFood.Entites;

namespace FastFood.ViewModels.Products;

public class ProductViewModel : Auditable
{

    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public long Quantity { get; set; }

    public float Price { get; set; }

    public short Discount { get; set; }

    public string Description { get; set; } = string.Empty;

}
