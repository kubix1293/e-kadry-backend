using System;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Pkzp;

namespace EKadry.Application.Services.Pkzp.PkzpCreate
{
    public class PkzpCreateCommand : CommandBase<PkzpDto>
    {
        public PkzpType PkzpType { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
        public Guid WorkerId { get; }
        public decimal Amount { get; }
        public int InstallmentsCount { get; }
        public decimal InstallmentAmount { get; }

        public PkzpCreateCommand(
            PkzpType pkzpType,
            DateTime dateFrom,
            DateTime dateTo,
            Guid workerId,
            decimal amount,
            int installmentsCount,
            decimal installmentAmount)
        {
            PkzpType = pkzpType;
            DateFrom = dateFrom;
            DateTo = dateTo;
            WorkerId = workerId;
            Amount = amount;
            InstallmentsCount = installmentsCount;
            InstallmentAmount = installmentAmount;
        }
    }
}