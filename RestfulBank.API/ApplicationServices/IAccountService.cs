using System;
using RestfulBank.API.Model;

namespace RestfulBank.API.ApplicationServices
{
    public interface IAccountService
    {
        CloseAccountResult CloseAccount(Guid accountId);
        Account GetAccount(Guid accountId);
        WithdrawResult Withdraw(Guid accountId, double amount);
    }
}