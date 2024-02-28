using FastFood.Entites.Orders;
using FastFood.Interfaces.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Repositories.Orders;

public class OrderRepositoryDetails : BaseRepository, IOrderRepositoryDetails
{
    public Task<long> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(OrderDetail entity)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<OrderDetail>> GetAllAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<OrderDetail> GetProductByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<OrderDetail>> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, OrderDetail entity)
    {
        throw new System.NotImplementedException();
    }
}
