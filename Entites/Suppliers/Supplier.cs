namespace FastFood.Entites.Suppliers;

public class Supplier : Auditable
{
    public string CompanyName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ContactPhoneNumber { get; set; } = string.Empty;

}
