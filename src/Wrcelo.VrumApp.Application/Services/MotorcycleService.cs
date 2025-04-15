using Infra.Data.Services;
using System.Text.Json;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Core.Events;
using Wrcelo.VrumApp.Core.Shared;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly RabbitMQService _rabbitMQService;


        public MotorcycleService(IMotorcycleRepository motorcycleRepository, RabbitMQService rabbitMQService)
        {
            _motorcycleRepository = motorcycleRepository;
            _rabbitMQService = rabbitMQService;
        }

        public async Task CreateMotorcycle(MotorcycleDTO motorcycleDto)
        {
            try
            {
                var motorcycle = Motorcycle.Create(motorcycleDto.Year, motorcycleDto.Model, motorcycleDto.LicensePlate.ToUpper());

                if (motorcycle.IsFailure)
                {
                    throw new Exception(JsonSerializer.Serialize(motorcycle.Errors));
                }
                var isLicensePlateAlreadyRegistered = await _motorcycleRepository.GetMotorcycleByLicensePlate(motorcycle.Value.LicensePlate) is not null;
                if (isLicensePlateAlreadyRegistered)
                {
                    throw new Exception("Essa placa já foi cadastrada.");
                }

                var evento = new MotorcyclePostedEvent(motorcycle.Value.Guid, motorcycle.Value.Model, motorcycle.Value.Year, DateTime.UtcNow);
                var mensagem = JsonSerializer.Serialize(evento);
                _rabbitMQService.Publish(mensagem);



                await _motorcycleRepository.CreateMotorcycle(motorcycle.Value);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task DeleteMotorcycle(Guid guid)
        {

            if (await _motorcycleRepository.IsMotorcycleReadyToDelete(guid) == false)
            {
                throw new Exception("Não é possível remover essa moto já que a mesma possui no mínimo uma locação.");
            }

            await _motorcycleRepository.DeleteMotorcycle(guid);
        }

        public async Task EditMotorcycleLicensePlate(Guid id, EditMotorcycleDTO editMotorcycleDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(editMotorcycleDTO.LicensePlate))
                {
                    throw new Exception("License plate cannot be empty.");
                }

                if (!LicensePlateValidator.IsValid(editMotorcycleDTO.LicensePlate))
                {
                    throw new Exception("License plate format is invalid.");
                }

                await _motorcycleRepository.EditMotorcycleLicensePlate(id, editMotorcycleDTO);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Motorcycle> GetMotorcycleByGuid(Guid id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString()))
                {
                    throw new Exception("Request mal formada");
                }
                var motorcycle = await _motorcycleRepository.GetMotorcycleByGuid(id);

                return motorcycle;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<IEnumerable<Motorcycle>> GetMotorcycles()
        {
            try
            {
                var motorcycles = await _motorcycleRepository.GetMotorcycles();

                return motorcycles;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetMotorcycleByLicensePlate(licensePlate);
                return motorcycle;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
