using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Text.Json;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class RentalService : IRentalService
    {

        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task CreateRental(RentalDTO rentalDto)
        {
            var rental = Rental.Create(rentalDto);

            if (rental.IsFailure)
            {
                throw new Exception(JsonSerializer.Serialize(rental.Errors));
            }

            if (!await _rentalRepository.IsDriverLicenseTypeA(rentalDto.DeliveryDriverGuid))
            {
                throw new Exception("Não é possível alugar uma moto pois o entregador não possui carteira categoria A cadastrada.");
            }

            if (!await _rentalRepository.IsMotorcycleAvailable(rentalDto.MotorcycleGuid, rentalDto.StartDate, rentalDto.EndDate))
                throw new Exception("Essa moto já está em uso em outra locação");

            await _rentalRepository.CreateRental(rental.Value);

        }

        public async Task<Rental> GetRentalById(Guid rentalGuid)
        {
            if (string.IsNullOrWhiteSpace(rentalGuid.ToString()))
                throw new Exception("Passe o ID para fazer a busca da locação");

            return await _rentalRepository.GetRentalById(rentalGuid);
        }

        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            return await _rentalRepository.GetAllRentals();
        }

        public async Task RentalUpdateEndDate(UpdateEndDateDTO updateEndDateDto, Guid id)
        {
            Rental rental = await _rentalRepository.GetRentalById(id);
            if (rental is null)
                throw new Exception("Locação não entrada.");

            if(updateEndDateDto.DevolutionDate < rental.StartDate)
            {
                throw new Exception("A data de devolução deve ser menor que a data de início da locação");
            }

            rental.EndRental(updateEndDateDto.DevolutionDate);

            await _rentalRepository.UpdateRental(rental);
        }
    }
}
