using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class AccountDoesNotAllowWithdrawalsProblem : ProblemDetails
    {
        public AccountDoesNotAllowWithdrawalsProblem()
        {
            Detail = "Unfortunately the provided account does not allow withdrawals.";
        }
    }
}
