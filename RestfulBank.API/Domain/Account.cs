using System;
using System.Linq;

namespace RestfulBank.API.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool CanWithdraw { get; set; }
        public bool CanClose { get; set; }
        public bool IsClosed { get; set; }

        public WithdrawStatus Withdraw(double amount)
        {
            if (!CanWithdraw)
            {
                return WithdrawStatus.AccountDoesNotAllowWithdrawals;
            }

            if (amount <= Amount)
            {
                Amount -= amount;
                return  WithdrawStatus.Success;
            }
            else
            {
                return  WithdrawStatus.InsufficientFunds;
            }
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Amount += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public CloseResult Close()
        {
            if (CanClose)
            {
                if (Amount == 0)
                {
                    IsClosed = true;
                    CanClose = false;

                    return  CloseResult.Ok;
                }
                else
                {
                    return CloseResult.AccountIsNotEmpty;
                }
            }
            else
            {
                return  CloseResult.AccountCannotBeClosed;
            }
        }
    }
}
