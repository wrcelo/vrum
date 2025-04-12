using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IMotorcycleService
    {
        Task CreateMotorcycle(MotorcycleDTO motorcycleDto);
        Task<IEnumerable<Motorcycle>> GetMotorcycles();
        Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate);
        Task EditMotorcycleLicensePlate(Guid id, EditMotorcycleDTO editMotorcycleDTO);
        Task<Motorcycle> GetMotorcycleByGuid(Guid id);
        Task DeleteMotorcycle(Guid id);
    }
}
