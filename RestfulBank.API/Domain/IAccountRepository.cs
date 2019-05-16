using System;

namespace RestfulBank.API.Domain
{
    public interface IAccountRepository
    {
        Account GetAccount(Guid accountId);
    }
}