using System;

namespace RestfulBank.API.Domain
{
    public class BankingService
    {
        public WithdrawResult Withdraw(DailyPolicy policy, Account account, double amount, DateTime now)
        {
            var reservation = policy.Reserve(amount, now);

            if (reservation == null)
            {
                return WithdrawResult.DailyQuotaReached(policy.DailyLimit);
            }

            var withdrawResult = account.Withdraw(amount);

            if (withdrawResult == WithdrawStatus.InsufficientFunds)
            {
                reservation.Cancel();

                return WithdrawResult.InsufficientFunds(account.Amount);
            }
            else if (withdrawResult == WithdrawStatus.AccountDoesNotAllowWithdrawals)
            {
                return WithdrawResult.AccountCannotWithdraw();
            }

            return WithdrawResult.Success();
        }

        public TransferResult Transfer(DailyPolicy policy, Account source, Account destination, double amount, string reason, DateTime now)
        {
            if (string.IsNullOrWhiteSpace(reason))
            {
                return TransferResult.InvalidReasonProvided();
            }

            var reservation = policy.Reserve(amount, now);

            if (reservation == null)
            {
                return TransferResult.DailyQuotaReached(policy.DailyLimit);
            }

            var withdrawResult = source.Withdraw(amount);

            if (withdrawResult == WithdrawStatus.InsufficientFunds)
            {
                reservation.Cancel();

                return TransferResult.InsufficientFunds(source.Amount);
            }
            else if (withdrawResult == WithdrawStatus.AccountDoesNotAllowWithdrawals)
            {
                reservation.Cancel();

                return TransferResult.AccountCannotWithdraw();
            }

            if (!destination.Deposit(amount))
            {
                reservation.Cancel();
                source.Deposit(amount);
            }

            return TransferResult.Success();
        }
    }
}
