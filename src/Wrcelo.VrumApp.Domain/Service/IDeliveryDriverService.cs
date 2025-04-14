using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IDeliveryDriverService
    {
        Task CreateDeliveryDriver(DeliveryDriverDTO deliveryDriverDTO);
        Task UpdateLicenseImage(Guid deliveryDriverId, string licenseImageBase64);
        Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers();
    }
}
