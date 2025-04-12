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
        Task<bool> CreateMotorcycle(MotorcycleDTO motorcycleDto);
        Task<IEnumerable<Motorcycle>> GetMotorcycles();
        Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate);
        Task<bool> EditMotorcycleLicensePlate(int motorcycleId, EditMotorcycleDTO editMotorcycleDTO);
        Task<Motorcycle> GetMotorcycleByGuid(int motorcycleId);
        Task DeleteMotorcycle(int motorcycleId);
    }
}
