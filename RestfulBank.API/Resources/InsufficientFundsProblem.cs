using System;

namespace RestfulBank.API.Resources
{
    public class InsufficientFundsProblem : ProblemDetails
    {
        public InsufficientFundsProblem(string type, double availableFunds)
            : base(type)
        {
            AvailableFunds = availableFunds;
            Detail = $"Unfortunately you do not have enough funds. The available amount is {availableFunds} EUR.";
        }

        public double AvailableFunds { get; private set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.problems.insufficientfunds+json"; 
        }
    }
}
