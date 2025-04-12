using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class Rental
    {
        public int Id { get; set; }

        public int DeliveryDriverId { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }

        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int PlanDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
