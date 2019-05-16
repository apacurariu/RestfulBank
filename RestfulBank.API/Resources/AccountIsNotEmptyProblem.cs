using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class AccountIsNotEmptyProblem : ProblemDetails
    {
        public AccountIsNotEmptyProblem(Guid accountId)
        {
            AccountId = accountId;
            Detail = "Unfortunately you have to clear out all the funds in the account before closing it.";
        }

        public Guid AccountId { get; private set; }
    }
}
