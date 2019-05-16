using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class InvalidReasonProblem : ProblemDetails
    {
        public InvalidReasonProblem(string type)
            : base(type)
        {
            Detail = "Please provide a valid transfer reason.";
        }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.invalidreason+json";
        }
    }
}
