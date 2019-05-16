using RestfulBank.API.Infrastructure;
using RestfulBank.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.ApplicationServices
{
    public class OverviewProvider : IOverviewProvider
    {
        public Overview GetOverview()
        {
            var overview = new Overview();

            DB.Accounts
                .Where(a => !a.IsClosed)
                .Select(a => new Model.Account()
                {
                    Amount = a.Amount,
                    CanClose = a.CanClose,
                    CanWithdraw = a.CanWithdraw,
                    Currency = a.Currency,
                    IBAN = a.IBAN,
                    Id = a.Id,
                    Name = a.Name

                }).ToList()
            .ForEach(a => overview.Accounts.Add(a));

            return overview;
        }
    }
}
