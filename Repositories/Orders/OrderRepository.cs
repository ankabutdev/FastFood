using FastFood.Entites.Orders;
using FastFood.Interfaces.Orders;
using FastFood.Utils;
using FastFood.ViewModels.Orders;
using System.Collections.Generic;
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

    public Task<IList<OrderViewModel>> GetAllAsync()
    {
        throw new System.NotImplementedException();
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
