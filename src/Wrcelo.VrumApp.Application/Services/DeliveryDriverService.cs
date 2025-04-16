using System.Text.Json;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class DeliveryDriverService : IDeliveryDriverService
    {
        private readonly MinioStorageService _minioStorageService;
        private readonly IDeliveryDriverRepository _deliveryDriverRepository;
        private readonly IUserRepository _userRepository;

    public DeliveryDriverService(IDeliveryDriverRepository deliveryDriverRepository, IUserRepository userRepository, MinioStorageService minioStorageService)
        {
            _minioStorageService = minioStorageService;
            _deliveryDriverRepository = deliveryDriverRepository;
            _userRepository = userRepository;
        }

        public async Task CreateDeliveryDriver(DeliveryDriverDTO deliveryDriverDto)
        {
            
                Guid userGuid = Guid.NewGuid();

                var deliveryDriver = DeliveryDriver.Create(deliveryDriverDto.Name, deliveryDriverDto.Cnpj, deliveryDriverDto.BirthDate, deliveryDriverDto.DriverLicenseNumber, deliveryDriverDto.DriverLicenseType, "");
                if (deliveryDriver.IsFailure)
                {
                    throw new Exception(JsonSerializer.Serialize(deliveryDriver.Errors));
                }


                await _userRepository.AddAsync(new User
                {
                    Guid = userGuid,
                    Email = deliveryDriverDto.Email,
                    Name = deliveryDriverDto.Name,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(deliveryDriverDto.Password),
                    Role = deliveryDriverDto.Role
                });

                var deliveryGuid = await _deliveryDriverRepository.CreateDeliveryDriver(deliveryDriver.Value, userGuid);
                await UpdateLicenseImage(deliveryGuid, deliveryDriverDto.DriverLicenseImageBase64);
           
        }

        public async Task UpdateLicenseImage(Guid deliveryDriverId, string licenseImageBase64)
        {
            var deliveryDriver = await _deliveryDriverRepository.GetDeliveryDriverById(deliveryDriverId);
            if (deliveryDriver is null)
                throw new Exception($"Entregador não encontrado com id {deliveryDriverId}");

            var fileName = $"cnh_{deliveryDriverId}_{DateTime.UtcNow.ToString()}.jpg";

            var imagePath = await _minioStorageService.UploadBase64ImageAsync(licenseImageBase64, fileName);

            deliveryDriver.UpdateImagePath(imagePath);
            await _deliveryDriverRepository.UpdateDriverLicenseImage(deliveryDriver, imagePath);
        }

        public async Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers()
        {
            return await _deliveryDriverRepository.GetAllDeliveryDrivers();
        }

        public async Task<DeliveryDriver> GetDeliveryDriverById(Guid id)
        {
            return await _deliveryDriverRepository.GetDeliveryDriverById(id);
        }
    }
}
