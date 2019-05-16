using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class AccountDoesNotAllowWithdrawalsProblem : ProblemDetails
    {
        public AccountDoesNotAllowWithdrawalsProblem(string type)
            : base(type)
        {
            Detail = "Unfortunately the provided account does not allow withdrawals.";
        }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.accountdoesnotallowwithdrawals+json";
        }
    }
}
