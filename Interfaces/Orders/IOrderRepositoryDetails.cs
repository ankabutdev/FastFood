using FastFood.Common;
using FastFood.Entites.Orders;

namespace FastFood.Interfaces.Orders;

public interface IOrderRepositoryDetails : IRepository<OrderDetail, OrderDetail>,
    IGetAll<OrderDetail>, ISearchable<OrderDetail>
{
}
