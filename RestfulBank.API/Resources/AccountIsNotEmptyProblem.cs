using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class AccountIsNotEmptyProblem : ProblemDetails
    {
        public AccountIsNotEmptyProblem(string type, Guid accountId) 
            : base(type)
        {
            AccountId = accountId;
            Detail = "Unfortunately you have to clear out all the funds in the account before closing it.";
        }

        public Guid AccountId { get; private set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.problems.accountisnotempty+json"; ;
        }
    }
}
