using FastFood.Entites;
using FastFood.Entites.Products;

namespace FastFood.ViewModels.Orders;

public class OrderViewModel : Auditable
{
    public Product? Product { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

}
