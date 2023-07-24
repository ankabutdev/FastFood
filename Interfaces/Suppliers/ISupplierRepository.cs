using FastFood.Common;
using FastFood.Entites.Suppliers;
using FastFood.ViewModels.Suppliers;

namespace FastFood.Interfaces.Suppliers;

public interface ISupplierRepository : IRepository<Supplier, SuppliersViewModel>,
    IGetAll<Supplier>
{
}
