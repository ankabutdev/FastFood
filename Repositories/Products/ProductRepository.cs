using FastFood.Entites.Products;
using FastFood.Interfaces;
using FastFood.Interfaces.Products;
using FastFood.Utils;
using FastFood.ViewModels.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Repositories.Products;

public class ProductRepository : BaseRepository, IProductRepository
{
    public Task<int> CountAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<long> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(Product entity)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<ProductViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<ProductViewModel> GetByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<(int ItemCount, IList<ProductViewModel>)> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Product entity)
    {
        throw new System.NotImplementedException();
    }
}
