using System;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Application.Services.Pkzp.PkzpCreate
{
    public class PkzpCreateCommand : CommandBase<PkzpDto>
    {
        public PkzpPositionType PkzpPositionType { get; }
        public Guid PeriodId { get; }
        public Guid WorkerId { get; }
        public decimal Amount { get; }
        public int InstallmentsCount { get; }
        public decimal InstallmentAmount { get; }

        public PkzpCreateCommand(
            PkzpPositionType pkzpPositionType,
            Guid periodId,
            Guid workerId,
            decimal amount,
            int? installmentsCount,
            decimal? installmentAmount)
        {
            PkzpPositionType = pkzpPositionType;
            PeriodId = periodId;
            WorkerId = workerId;
            Amount = amount;
            InstallmentsCount = installmentsCount ?? 0;
            InstallmentAmount = installmentAmount ?? 0;
        }
    }
}