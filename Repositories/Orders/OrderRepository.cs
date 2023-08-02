using Dapper;
using FastFood.Entites.Orders;
using FastFood.Interfaces.Orders;
using FastFood.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Repositories.Orders;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public Task<long> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(Order entity)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IList<Order>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM orders ORDER BY id DESC";
            var result = (await _connection.QueryAsync<Order>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<OrderViewModel> GetByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<OrderViewModel>> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Order entity)
    {
        throw new System.NotImplementedException();
    }
}
