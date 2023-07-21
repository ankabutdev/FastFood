using FastFood.Common;
using FastFood.Entites.Products;
using FastFood.ViewModels.Products;

namespace FastFood.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
}
