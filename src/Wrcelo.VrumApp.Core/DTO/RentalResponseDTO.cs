using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.DTO
{
    public class RentalResponseDTO
    {
        public Guid Guid { get; set; }
        public Guid DeliveryDriverGuid { get; set; }
        public string DeliveryDriverName { get; set; }
        public Guid MotorcycleGuid { get; set; }
        public string MotorcycleModel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public int PlanDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
