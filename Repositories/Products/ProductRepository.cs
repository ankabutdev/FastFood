using Dapper;
using FastFood.Entites.Products;
using FastFood.Interfaces.Products;
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

            string query = "INSERT INTO products(name, description, image_path, unit_price, created_at, qunatity) " +
                "VALUES (@Name, @Description, @ImagePath, @UnitPrice, @CreatedAt, @Qunatity);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM products WHERE id={id}";
            var result = await _connection.ExecuteAsync(query, id);
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

    public async Task<IList<Product>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products order by id desc";
            var result = (await _connection.QueryAsync<Product>(query)).ToList();
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

    public async Task<Product> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products WHERE id=@Id";

            var result = await _connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
            return result;
        }
        catch
        {
            return new Product();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


    public Task<(int ItemCount, IList<Product>)> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE products SET name=@Name, description=@Description , " +
                "image_path=@ImagePath, unit_price=@UnitPrice, " +
                $" updated_at=@UpdatedAt, qunatity=@Qunatity WHERE id = {id} ;";


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

    public async Task<IList<Product>> GetAllByCategoryIdAsync(long categoryId)
    {
        try
        {
            await _connection.OpenAsync();
            string quary = $"SELECT * FROM Products WHERE CategoryId = {categoryId} order by id";
            var result = (await _connection.QueryAsync<Product>(quary)).ToList();
            return (IList<Product>)result;
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
