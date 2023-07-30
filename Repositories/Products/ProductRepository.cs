using Dapper;
using FastFood.Entites.Products;
using FastFood.Interfaces.Products;
using FastFood.Utils;
using FastFood.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.products(name, description, image_path, unit_price, category_id, company_id, created_at, updated_at) " +
                "VALUES (@Name, @Description, @ImagePath, @UnitPrice, @CategoryId, @CompanyId, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IList<ProductViewModel>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products order by id desc";
            var result = (await _connection.QueryAsync<ProductViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<ProductViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
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

    public async Task<IList<Product>> GetAllByCategoryIdAsync(long categoryId)
    {
        try
        {
            await _connection.OpenAsync();
            string quary = $"SELECT * FROM Products WHERE CategoryId = {categoryId} order by id";
            var result = (await _connection.QueryAsync<Product>(quary)).ToList();
            return result;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
