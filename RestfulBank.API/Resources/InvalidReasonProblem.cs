using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class InvalidReasonProblem : ProblemDetails
    {
        public InvalidReasonProblem()
        {
            Detail = "Please provide a valid transfer reason.";
        }
    }
}
