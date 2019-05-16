using Microsoft.AspNetCore.Mvc;
using RestfulBank.API.ApplicationServices;
using RestfulBank.API.Resources;
using System;

namespace RestfulBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountId}")]
        public IActionResult Get(Guid accountId)
        {
            var account = _accountService.GetAccount(accountId);

            if (account == null)
            {
                return this.NotFoundResource(new AccountNotFoundProblem(null, accountId));
            }
            else
            {
                return this.OkResource(ResourceFormatter.FormatAccount(account));
            }
        }

        [HttpPost("{accountId}/withdrawals")]
        public IActionResult Withdraw(Guid accountId, [FromBody]Withdrawal withdrawal)
        {
            var result = _accountService.Withdraw(accountId, withdrawal.Amount);

            if (result.Status == WithdrawStatus.Success)
            {
                return NoContent();
            }
            else if (result.Status == WithdrawStatus.AccountNotFound)
            {
                return this.NotFoundResource(new AccountNotFoundProblem(null, accountId));
            }
            else if (result.Status == WithdrawStatus.DailyQuotaReached)
            {
                return this.BadRequestResource(new DailyQuotaReachedProblem(null, result.DailyLimit));
            }
            else if (result.Status == WithdrawStatus.AccountDoesNotAllowWithdrawals)
            {
                return this.BadRequestResource(new AccountDoesNotAllowWithdrawalsProblem(null));
            }
            else //if (result.Status == WithdrawStatus.InsufficientFunds)
            {
                return this.BadRequestResource(new InsufficientFundsProblem(null, result.AvailableFunds));
            }
        }

        [HttpDelete("{accountId}")]
        public IActionResult Close(Guid accountId)
        {
            var result = _accountService.CloseAccount(accountId);

            if (result.Status == CloseAccountStatus.Success)
            {
                return NoContent();
            }
            else if (result.Status == CloseAccountStatus.AccountNotFound)
            {
                return this.NotFoundResource(new AccountNotFoundProblem(null, accountId));
            }
            else if (result.Status == CloseAccountStatus.AccountIsNotEmpty)
            {
                return this.BadRequestResource(new AccountIsNotEmptyProblem(null, accountId));
            }
            else //if (result.Status == CloseAccountStatus.AccountCannotBeClosed)
            {
                return this.BadRequestResource(new AccountCannotBeClosedProblem(null, accountId));
            }
        }
    }   
}
