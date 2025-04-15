using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IMotorcycleNotificationRepository
    {
        Task AddMotorcycleNotificationAsync(MotorcycleNotification notificacao);
    }
}
