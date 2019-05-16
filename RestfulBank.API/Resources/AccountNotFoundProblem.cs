using System;
using Microsoft.Net.Http.Headers;

namespace RestfulBank.API.Resources
{
    public class AccountNotFoundProblem : ProblemDetails
    {
        public AccountNotFoundProblem(string type, Guid accountId)
            : base(type)
        {
            AccountId = accountId;
            Detail = $"The provided account does not exist.";
        }
        
        public Guid AccountId { get; private set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.problems.accountnotfound+json"; 
        }
    }
}
