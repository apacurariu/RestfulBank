using RestfulBank.API.Domain;
using System;
using System.Linq;

namespace RestfulBank.API.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(Guid accountId)
        {
            return DB.Accounts.FirstOrDefault(a => a.Id == accountId);
        }
    }
}
