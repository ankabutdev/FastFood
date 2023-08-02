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

            string query = "INSERT INTO products(name, description, image_path, unit_price, created_at, qunatity, category_id) " +
                "VALUES (@Name, @Description, @ImagePath, @UnitPrice, @CreatedAt, @Qunatity, @CategoryId);";
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


    public async Task<IList<Product>> SearchAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products WHERE LOWER(Name) LIKE @SearchTerm";
            var parameters = new { SearchTerm = "%" + search.ToLower() + "%" };

            var result = (await _connection.QueryAsync<Product>(query, parameters)).ToList();
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
            string quary = $"SELECT * FROM Products WHERE category_id = {categoryId} order by id";
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

    public async Task<IList<Product>> SearchByCategoryIdFromProductAsync(long id, string search)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products WHERE category_id = @CategoryId AND LOWER(name) LIKE LOWER(@SearchTerm)";

            var parameters = new { CategoryId = id, SearchTerm = "%" + search.ToLower() + "%" };

            var result = (await _connection.QueryAsync<Product>(query, parameters)).ToList();
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
