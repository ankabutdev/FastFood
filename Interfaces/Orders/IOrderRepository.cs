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

    public Task<int> CreateOrderWithIsPaidTrueAsync(Order order, long orderId);

    public Task<Order> GetOrderByUserIdByProductId(long userId, long productId);

    public Task<bool> UpdateQuantityAndResultPriceAsync(long id, long orderQuantity, double resultPrice);

    public Task<bool> UpdateOrderIfIsPaidFalseToTrue(long orderId);
}