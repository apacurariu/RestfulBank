using System;
using RestfulBank.API.Model;

namespace RestfulBank.API.Resources
{
    public class Account : Resource<Model.Account>
    {
        public Account(string basePath, Model.Account model)
            : base(basePath, model)
        {
            Id = model.Id.ToString("n");
            IBAN = model.IBAN;
            Amount = model.Amount;
            Currency = model.Currency;
            Name = model.Name;

            AddSelf($"accounts/{Id}");

            if (model.CanWithdraw)
            {
                AddLink("withdraw", $"accounts/{Id}/withdrawals");
            }

            if (model.CanClose)
            {
                AddLink("close", $"accounts/{Id}");
            }
        }

        public string Id { get; private set; }
        public string IBAN { get; private set; }
        public string Name { get; private set; }
        public double Amount { get; private set; }
        public string Currency { get; private set; }
    }
}
