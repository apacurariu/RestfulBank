using System;

namespace RestfulBank.API.Resources
{
    public class Transfer : Resource
    {
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.transfer+json";
        }
    }
}
