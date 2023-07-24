using FastFood.Common;
using FastFood.Entites.Products;
using FastFood.ViewModels.Products;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
    public Task<int> CountAsync(long id);
}
