using System;

namespace RestfulBank.API.Resources
{
    public class Account : Resource
    {
        public string Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.account+json";
        }
    }
}
