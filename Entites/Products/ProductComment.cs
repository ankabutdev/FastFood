namespace FastFood.Entites.Products;

public class ProductComment : Auditable
{
    public long ProductId { get; set; }

    public long UserId { get; set; }

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}
