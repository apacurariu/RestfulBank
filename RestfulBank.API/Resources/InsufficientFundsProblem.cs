using System;

namespace RestfulBank.API.Resources
{
    public class InsufficientFundsProblem : ProblemDetails
    {
        public InsufficientFundsProblem(double availableFunds)
        {
            AvailableFunds = availableFunds;
            Detail = $"Unfortunately you do not have enough funds. The available amount is {availableFunds} EUR.";
        }

        public double AvailableFunds { get; private set; }
    }
}
