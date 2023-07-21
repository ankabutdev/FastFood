using FastFood.Common;
using FastFood.Entites.Deliveries;
using FastFood.ViewModels.Deliveries;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Deliver, Deliver>,
    IGetAll<DeliveryViewModel>
{
    public Task<DeliveryViewModel> GetDeliverAsync(long id);
}
