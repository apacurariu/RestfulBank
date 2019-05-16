using RestfulBank.API.Domain;
using System;

namespace RestfulBank.API.ApplicationServices
{
    public class TransfersService : ITransfersService
    {
        private readonly IDailyPolicyRespository _dailyPolicyRespository;
        private readonly IAccountRepository _accountRepository;

        public TransfersService(IDailyPolicyRespository dailyPolicyRespository, IAccountRepository accountRepository)
        {
            _dailyPolicyRespository = dailyPolicyRespository;
            _accountRepository = accountRepository;
        }

        public TransferResult Transfer(Guid sourceAccountId, Guid destinationAccountId, double amount, string reason)
        {
            var bankingService = new BankingService();

            var policy = _dailyPolicyRespository.GetDailyPolicy();
            var source = _accountRepository.GetAccount(sourceAccountId);
            var dest = _accountRepository.GetAccount(destinationAccountId);

            if (source == null)
            {
                return TransferResult.AccountNotFound(sourceAccountId);
            }

            if (dest == null)
            {
                return TransferResult.AccountNotFound(destinationAccountId);
            }

            var result = bankingService.Transfer(policy, source, dest, amount, reason, DateTime.Now);

            if (result.Status == Domain.TransferStatus.DailyQuotaReached)
            {
                return TransferResult.DailyQuotaReached(result.DailyLimit);
            }
            else if (result.Status == Domain.TransferStatus.InsufficientFunds)
            {
                return TransferResult.InsufficientFunds(result.AvailableFunds);
            }
            else if (result.Status == Domain.TransferStatus.InvalidReason)
            {
                return TransferResult.InvalidReasonProvided();
            }
            else if (result.Status == Domain.TransferStatus.AccountDoesNotAllowWithdrawals)
            {
                return TransferResult.AccountCannotWithdraw();
            }
            else
            {
                return TransferResult.Success();
            }
        }
    }
}
