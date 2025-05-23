﻿using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.Application.Services
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApiContext _context;
        public MotorcycleRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task CreateMotorcycle(Motorcycle motorcycle)
        {
           _context.Motorcycles.Add(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMotorcycle(Guid guid)
        {
            var motorcycle = await _context.Motorcycles.FirstOrDefaultAsync(x => x.Guid == guid);
            if(motorcycle is null){
                throw new Exception("Moto não foi encontrada para fazer exclusão.");
            }
            _context.Motorcycles.Remove(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task EditMotorcycleLicensePlate(Guid id, EditMotorcycleDTO editMotorcycleDTO)
        {
            var motorcycle = await _context.Motorcycles.FirstOrDefaultAsync(m => m.Guid == id);

            if (motorcycle == null)
                throw new KeyNotFoundException($"Motorcycle with ID {id} not found.");

            motorcycle.UpdateLicensePlate(editMotorcycleDTO.LicensePlate);

            _context.Motorcycles.Update(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task<Motorcycle> GetMotorcycleByGuid(Guid id)
        {
            var result = await _context.Motorcycles.FirstAsync(m => m.Guid == id);
            return result;
        }

        async Task<Motorcycle> IMotorcycleRepository.GetMotorcycleByLicensePlate(string licensePlate)
        {
            var result = await _context.Motorcycles.FirstOrDefaultAsync(m => m.LicensePlate == licensePlate);

            return result;
        }

        async Task<IEnumerable<Motorcycle>> IMotorcycleRepository.GetMotorcycles()
        {
            var result = await _context.Motorcycles.ToListAsync();
            return result;
        }

        async Task<bool> IMotorcycleRepository.IsMotorcycleReadyToDelete(Guid motorcycleGuid)
        {
            var result = await _context.Rentals.Where(r => r.MotorcycleGuid == motorcycleGuid).ToListAsync();
            return result.Count == 0;
        }
    }
}
