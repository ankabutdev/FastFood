using FastFood.Common;
using FastFood.Entites.Orders;
using FastFood.ViewModels.Baskets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Orders;

public interface IOrderRepositoryDetails : IRepository<OrderDetail, OrderDetail>,
    IGetAll<OrderDetail>, ISearchable<OrderDetail>
{
    public Task<bool> UpdateQuantityAsync(long id, long orderQuantity);

    public Task<IList<BasketViewModel>> GetBasketAsync();
}
