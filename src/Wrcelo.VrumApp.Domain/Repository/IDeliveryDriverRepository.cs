using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IDeliveryDriverRepository
    {
        Task CreateDeliveryDriver(DeliveryDriver deliveryDriver, Guid userGuid);
        Task UpdateDriverLicenseImage(string base64ImageString);

        Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers();
    }
}
