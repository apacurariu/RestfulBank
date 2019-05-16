using System;

namespace RestfulBank.API.ApplicationServices
{
    public class WithdrawResult
    {
        public WithdrawStatus Status { get; private set; }
        public double DailyLimit { get; private set; }
        public double AvailableFunds { get; private set; }
        public Guid MissingAccountId { get; private set; }

        internal static WithdrawResult AccountNotFound(Guid accountId)
        {
            return new WithdrawResult()
            {
                Status = WithdrawStatus.AccountNotFound,
                MissingAccountId = accountId
            };
        }

        internal static WithdrawResult DailyQuotaReached(double dailyLimit)
        {
            return new WithdrawResult()
            {
                Status = WithdrawStatus.DailyQuotaReached,
                DailyLimit = dailyLimit
            };
        }

        internal static WithdrawResult InsufficientFunds(double amount)
        {
            return new WithdrawResult()
            {
                Status = WithdrawStatus.InsufficientFunds,
                AvailableFunds = amount
            };
        }

        internal static WithdrawResult Success()
        {
            return new WithdrawResult() { Status = WithdrawStatus.Success };
        }

        internal static WithdrawResult AccountCannotWithdraw()
        {
            return new WithdrawResult() { Status = WithdrawStatus.AccountDoesNotAllowWithdrawals };
        }
    }
}
