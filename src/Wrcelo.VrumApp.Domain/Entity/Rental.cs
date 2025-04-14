namespace Wrcelo.VrumApp.Domain.Entity
{
    public class Rental
    {
        public Guid Id { get; set; }

        public Guid DeliveryDriverId { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }

        public Guid MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int PlanDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
