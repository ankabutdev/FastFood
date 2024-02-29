using FastFood.Common;
using FastFood.Entites.Orders;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Orders;

public interface IOrderRepositoryDetails : IRepository<OrderDetail, OrderDetail>,
    IGetAll<OrderDetail>, ISearchable<OrderDetail>
{
    public Task<bool> UpdateQuantityAsync(long id, long orderQuantity);
}
