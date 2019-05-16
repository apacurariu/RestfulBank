using System;

namespace RestfulBank.API.ApplicationServices
{
    public class TransferResult
    {
        public TransferStatus Status { get; private set; }
        public double DailyLimit { get; private set; }
        public double AvailableFunds { get; private set; }
        public Guid MissingAccountId { get; set; }

        internal static TransferResult AccountNotFound(Guid missingAccountId)
        {
            return new TransferResult()
            {
                Status = TransferStatus.AccountNotFound,
                MissingAccountId = missingAccountId
            };
        }

        internal static TransferResult DailyQuotaReached(double dailyLimit)
        {
            return new TransferResult()
            {
                Status = TransferStatus.DailyQuotaReached,
                DailyLimit = dailyLimit
            };
        }

        internal static TransferResult InsufficientFunds(double amount)
        {
            return new TransferResult()
            {
                Status = TransferStatus.InsufficientFunds,
                AvailableFunds = amount
            };
        }

        internal static TransferResult InvalidReasonProvided()
        {
            return new TransferResult()
            {
                Status = TransferStatus.InvalidReason
            };
        }

        internal static TransferResult Success()
        {
            return new TransferResult()
            {
                Status = TransferStatus.Success
            };
        }

        internal static TransferResult AccountCannotWithdraw()
        {
            return new TransferResult()
            {
                Status = TransferStatus.AccountDoesNotAllowWithdrawals
            };
        }
    }
}
