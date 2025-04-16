using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IDeliveryDriverRepository
    {
        Task<Guid> CreateDeliveryDriver(DeliveryDriver deliveryDriver, Guid userGuid);
        Task UpdateDriverLicenseImage(DeliveryDriver deliveryDriver, string base64ImageString);

        Task<DeliveryDriver> GetDeliveryDriverById(Guid id);
        Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers();
    }
}
