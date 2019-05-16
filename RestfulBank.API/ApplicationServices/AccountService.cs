using RestfulBank.API.Domain;
using System;

namespace RestfulBank.API.ApplicationServices
{
    public class AccountService : IAccountService
    {
        private readonly IDailyPolicyRespository _dailyPolicyRespository;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IDailyPolicyRespository dailyPolicyRespository, IAccountRepository accountRepository)
        {
            _dailyPolicyRespository = dailyPolicyRespository;
            _accountRepository = accountRepository;
        }

        public Model.Account GetAccount(Guid accountId)
        {
            var account = _accountRepository.GetAccount(accountId);

            if (account == null)
            {
                return null;
            }
            else
            {
                return new Model.Account()
                {
                    Amount = account.Amount,
                    CanClose = account.CanClose,
                    CanWithdraw = account.CanWithdraw,
                    Currency = account.Currency,
                    IBAN = account.IBAN,
                    Id = account.Id,
                    Name = account.Name
                };
            }
        }

        public WithdrawResult Withdraw(Guid accountId, double amount)
        {
            var policy = _dailyPolicyRespository.GetDailyPolicy();

            var account = _accountRepository.GetAccount(accountId);

            if (account == null)
            {
                return WithdrawResult.AccountNotFound(accountId);
            }

            var bankingService = new BankingService();

            var result = bankingService.Withdraw(policy, account, amount, DateTime.Now);

            if (result.Status == Domain.WithdrawStatus.DailyQuotaReached)
            {
                return WithdrawResult.DailyQuotaReached(result.DailyLimit);
            }
            else if (result.Status == Domain.WithdrawStatus.InsufficientFunds)
            {
                return WithdrawResult.InsufficientFunds(result.AvailableFunds);
            }
            else if (result.Status == Domain.WithdrawStatus.AccountDoesNotAllowWithdrawals)
            {
                return WithdrawResult.AccountCannotWithdraw();
            }
            else
            {
                return WithdrawResult.Success();
            }

        }

        public CloseAccountResult CloseAccount(Guid accountId)
        {
            var account = _accountRepository.GetAccount(accountId);

            if (account == null)
            {
                return CloseAccountResult.AccountNotFound(accountId);
            }

            var closeResult = account.Close();
            if (closeResult == CloseResult.AccountCannotBeClosed)
            {
                return CloseAccountResult.CannotCloseAccount();
            }
            else if (closeResult == CloseResult.AccountIsNotEmpty)
            {
                return CloseAccountResult.AccountIsNotEmpty();
            }
            else
            {
                return CloseAccountResult.Success();
            }
        }
    }
}
