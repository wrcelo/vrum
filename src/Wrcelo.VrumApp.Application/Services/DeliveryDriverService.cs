using System.Text.Json;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class DeliveryDriverService : IDeliveryDriverService
    {
        private readonly IDeliveryDriverRepository _deliveryDriverRepository;
        private readonly IUserRepository _userRepository;

        public DeliveryDriverService(IDeliveryDriverRepository deliveryDriverRepository, IUserRepository userRepository)
        {
            _deliveryDriverRepository = deliveryDriverRepository;
            _userRepository = userRepository;
        }

        public async Task CreateDeliveryDriver(DeliveryDriverDTO deliveryDriverDTO)
        {
            try
            {
                Guid userGuid = Guid.NewGuid();

                var deliveryDriver = DeliveryDriver.Create(deliveryDriverDTO.Name, deliveryDriverDTO.Cnpj, deliveryDriverDTO.BirthDate, deliveryDriverDTO.DriverLicenseNumber, deliveryDriverDTO.DriverLicenseType, deliveryDriverDTO.DriverLicenseImageBase64);
                if (deliveryDriver.IsFailure)
                {
                    throw new Exception(JsonSerializer.Serialize(deliveryDriver.Errors));
                }


                await _userRepository.AddAsync(new User
                {
                    Guid = userGuid,
                    Email = deliveryDriverDTO.Email,
                    Name = deliveryDriverDTO.Name,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(deliveryDriverDTO.Password),
                    Role = deliveryDriverDTO.Role
                });

                await _deliveryDriverRepository.CreateDeliveryDriver(deliveryDriver.Value, userGuid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task UpdateLicenseImage(Guid deliveryDriverId, string licenseImageBase64)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers()
        {
            return await _deliveryDriverRepository.GetAllDeliveryDrivers();
        }
    }
}
