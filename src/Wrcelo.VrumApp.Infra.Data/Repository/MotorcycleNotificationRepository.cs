using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.Infra.Data.Repository
{
    public class MotorcycleNotificationRepository : IMotorcycleNotificationRepository
    {
        private readonly ApiContext _context;

        public MotorcycleNotificationRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task AddMotorcycleNotificationAsync(MotorcycleNotification notificacao)
        {
            await _context.MotorcycleNotifications.AddAsync(notificacao);
            await _context.SaveChangesAsync();
        }
    }
}
