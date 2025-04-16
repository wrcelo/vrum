using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.Infra.Data.Repository
{
    public class DeliveryDriverRepository : IDeliveryDriverRepository
    {
        private readonly ApiContext _context;
        public DeliveryDriverRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateDeliveryDriver(DeliveryDriver deliveryDriver, Guid userGuid)
        {
            var guidDelivery = Guid.NewGuid();
            deliveryDriver.UserGuid = userGuid;
            deliveryDriver.Guid = guidDelivery;

            await _context.DeliveryDrivers.AddAsync(deliveryDriver);
            await _context.SaveChangesAsync();

            return guidDelivery;
        }

        public async Task UpdateDriverLicenseImage(DeliveryDriver deliveryDriver, string base64ImageString)
        {
            _context.Update(deliveryDriver);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers()
        {

            return await _context.DeliveryDrivers.ToListAsync();

        }

        public async Task<DeliveryDriver> GetDeliveryDriverById(Guid id)
        {
            return await _context.DeliveryDrivers.FirstOrDefaultAsync(dd => dd.Guid == id);
        }
    }
}
