using FastFood.Common;
using FastFood.Entites.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Products;

public interface IProductRepository : IRepository<Product, Product>,
    IGetAll<Product>, ISearchable<Product>
{
    public Task<int> CountAsync(long id);

    public Task<IList<Product>> SearchByCategoryIdFromProductAsync(long id, string search);
}
