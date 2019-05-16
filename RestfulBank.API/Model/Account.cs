using System;

namespace RestfulBank.API.Model
{
    public class Account
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool CanWithdraw { get; set; }
        public bool CanClose { get; set; }
    }
}
