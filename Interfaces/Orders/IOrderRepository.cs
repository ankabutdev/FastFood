using FastFood.Entites.Orders;
using FastFood.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Orders
{
    public interface IOrderRepository : IRepository<Order, OrderViewModel>
    {

    }
}
