using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IDeliveryDriverRepository
    {
        Task CreateDeliveryDriver(DeliveryDriver deliveryDriver, Guid userGuid);
        Task UpdateDriverLicenseImage(string base64ImageString);

        Task<DeliveryDriver> GetDeliveryDriverById(Guid id);
        Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers();
    }
}
