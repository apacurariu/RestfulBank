using System.Linq;
using RestfulBank.API.Resources;

namespace RestfulBank.API.Controllers
{
    public static class ResourceFormatter
    {
        public static Overview FormatOverview(Model.Overview overviewModel)
        {
            var overview = new Overview();

            overview.Links.Add(new Link() { Rel = "self", Url = "/api", Media = overview.GetMediaType(), Method = "get" });
            overview.Links.Add(new Link() { Rel = "transfers", Url = "/transfers", Media = (new Transfer()).GetMediaType(), Method = "post" });

            overviewModel.Accounts
                .Select(a => FormatAccount(a))
                .ToList()
                .ForEach(a => overview.Accounts.Add(a));

            return overview;
        }

        public static Account FormatAccount(Model.Account accountModel)
        {
            var account = new Account()
            {
                Name = accountModel.Name,
                IBAN = accountModel.IBAN,
                Amount = accountModel.Amount,
                Currency = accountModel.Currency,
                Id = accountModel.Id.ToString("n")
            };

            account.Links.Add(new Link() { Rel = "self", Url = $"/api/accounts/{account.Id:n}", Media = account.GetMediaType(), Method = "get" });

            if (accountModel.CanWithdraw)
            {
                account.Links.Add(new Link() { Rel = "withdraw", Url = $"/api/accounts/{account.Id:n}/withdrawals", Media = (new Withdrawal()).GetMediaType(), Method = "post" });
            }

            if (accountModel.CanClose)
            {
                account.Links.Add(new Link() { Rel = "close", Url = $"/api/accounts/{account.Id:n}", Method = "delete" });
            }

            return account;
        }
    }
}
