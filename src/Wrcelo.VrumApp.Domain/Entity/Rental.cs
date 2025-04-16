using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Core.Shared;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class Rental
    {
        private Rental(Guid deliveryDriverGuid, Guid motorcycleGuid, DateTime startDate, DateTime expectedEndDate, int planDays, decimal dailyRate, decimal? totalAmount)
        {
            DeliveryDriverGuid = deliveryDriverGuid;
            MotorcycleGuid = motorcycleGuid;
            StartDate = startDate;
            ExpectedEndDate = expectedEndDate;
            PlanDays = planDays;
            DailyRate = dailyRate;
            TotalAmount = totalAmount;
        }

        public Guid Guid { get; private set; }

        public Guid DeliveryDriverGuid { get; private set; }
        public DeliveryDriver DeliveryDriver { get; private set; }

        public Guid MotorcycleGuid { get; private set; }
        public Motorcycle Motorcycle { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public DateTime? ActualEndDate { get; private set; }

        public int PlanDays { get; private set; }
        public decimal DailyRate { get; private set; }
        public decimal? TotalAmount { get; private set; }

        public static Result<Rental> Create(RentalDTO rentalDto)
        {
            var errors = new List<string>();

            if (rentalDto.StartDate == default)
                errors.Add("A data de início é obrigatória.");

            if (rentalDto.EndDate == default)
                errors.Add("A data de término prevista é obrigatória.");

            if (rentalDto.StartDate > rentalDto.EndDate)
                errors.Add("A data de início deve ser anterior à data de término prevista.");

            var daysPeriod = (rentalDto.EndDate - rentalDto.StartDate).Days;

            if (daysPeriod != rentalDto.PlanDays)
                errors.Add($"O período de {daysPeriod} ({rentalDto.StartDate.ToShortDateString()} - {rentalDto.EndDate.ToShortDateString()}) dias não corresponde ao plano selecionado de {rentalDto.PlanDays} dias.");

            if (rentalDto.PlanDays <= 0)
                errors.Add("A quantidade de dias do plano deve ser maior que 0.");

            if (rentalDto.DeliveryDriverGuid == Guid.Empty)
                errors.Add("O Guid do entregador é obrigatório.");

            if (rentalDto.MotorcycleGuid == Guid.Empty)
                errors.Add("O Guid da motocicleta é obrigatório.");


            decimal dailyRate = 0;

            try
            {
                dailyRate = GetDailyRate(rentalDto.PlanDays);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            if (errors.Count > 0)
                return Result<Rental>.Failure(errors);

            var totalAmount = dailyRate * rentalDto.PlanDays;

            var rental = new Rental(
                rentalDto.DeliveryDriverGuid,
                rentalDto.MotorcycleGuid,
                rentalDto.StartDate,
                rentalDto.EndDate,
                rentalDto.PlanDays,
                dailyRate,
                totalAmount
            );

            return Result<Rental>.Success(rental);
        }

        private static decimal GetDailyRate(int planDays)
        {
            if (planDays == 7)
            {
                return 30m;
            }

            if (planDays == 15)
            {
                return 28m;
            }

            if (planDays == 30)
            {
                return 22m;
            }
            if (planDays == 45)
            {
                return 20m;
            }
            if (planDays == 50)
            {
                return 18m;
            }

            throw new Exception($"O plano de {planDays} dias não existe.");
        }

        public void EndRental(DateTime actualEndDate)
        {
            if (actualEndDate < StartDate)
                throw new ArgumentException("A data de término não pode ser anterior à data de início.");

            ActualEndDate = actualEndDate;

            var totalDaysUsed = (ActualEndDate.Value - StartDate).Days;

            if (totalDaysUsed == 0)
            {
                totalDaysUsed = 1;
            }

            if (actualEndDate < ExpectedEndDate)
            {
                // devolução antecipada
                var usedDays = (actualEndDate - StartDate).Days;
                if (usedDays == 0)
                    usedDays = 1;

                var usedAmount = usedDays * DailyRate;
                var unusedDays = PlanDays - usedDays;

                decimal penaltyRate = 0;

                switch (PlanDays)
                {
                    case 7:
                        penaltyRate = 0.20m;
                        break;
                    case 15:
                        penaltyRate = 0.40m;
                        break;
                    default:
                        penaltyRate = 0;
                        break;
                }

                var penaltyAmount = unusedDays * DailyRate * penaltyRate;
                TotalAmount = usedAmount + penaltyAmount;
            }
            else if (actualEndDate > ExpectedEndDate)
            {
                // devolução com atraso
                var extraDays = (actualEndDate - ExpectedEndDate).Days;
                if (extraDays == 0)
                    extraDays = 1;

                var extraCost = extraDays * 50m;
                TotalAmount += extraCost;
            }
        }



    }
}
