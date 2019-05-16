using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class AccountCannotBeClosedProblem : ProblemDetails
    {
        public AccountCannotBeClosedProblem(Guid accountId)
        {
            Detail = "Unfortunately the provided account cannot be closed.";
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}
