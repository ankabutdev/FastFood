using FastFood.Common;
using FastFood.Entites.Discounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Discounts;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{
    public Task<IList<Discount>> GetAllByDurationAsync(DateTime startat, DateTime endat);
}
