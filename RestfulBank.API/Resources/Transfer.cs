using System;

namespace RestfulBank.API.Resources
{
    public class Transfer
    {
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
    }
}
