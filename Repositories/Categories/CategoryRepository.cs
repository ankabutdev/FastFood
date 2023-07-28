using Dapper;
using FastFood.Constants;
using FastFood.Entites.Categories;
using FastFood.Interfaces.Categories;
using FastFood.Utils;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace FastFood.Repositories.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    
    public Task<long> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Category entity)
    {   
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.categories(name, description, image_path, created_at, updated_at)" +
                "VALUES (@Name, @Description, @ImagePath, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE FROM categories WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories order by id desc " +
                $"offset {@params.SkipCount} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Category>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Category entity)
    {
        throw new System.NotImplementedException();
    }
}
