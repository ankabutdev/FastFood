using FastFood.Common;
using FastFood.Entites.Orders;
using FastFood.ViewModels.Orders;

namespace FastFood.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, OrderViewModel>,
    IGetAll<OrderViewModel>, ISearchable<OrderViewModel>
{
}