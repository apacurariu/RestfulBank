using System;
using Microsoft.Net.Http.Headers;

namespace RestfulBank.API.Resources
{
    public class AccountNotFoundProblem : ProblemDetails
    {
        public AccountNotFoundProblem(Guid accountId)
        {
            AccountId = accountId;
            Detail = $"The provided account does not exist.";
        }
        
        public Guid AccountId { get; private set; }
    }
}
