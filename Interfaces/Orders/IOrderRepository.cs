using FastFood.Common;
using FastFood.Entites.Orders;
using FastFood.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, OrderViewModel>,
    IGetAll<Order>, ISearchable<OrderViewModel>
{
    public Task<IList<Order>> GetAllOrderByUserIdByIsPaidFalseAsync(long userId);

    public Task<IQueryable<Order>> GetAllOrderByUserIdByIsPaidTrueAsync(long userId);
}