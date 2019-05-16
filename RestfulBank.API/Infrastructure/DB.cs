using RestfulBank.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Infrastructure
{
    public static class DB
    {
        static DB()
        {
            Accounts = new List<Account>();

            Accounts.Add(new Account()
            {
                Name = "Basic Current",
                IBAN = "RSTB01ABC1234567Q",
                Amount = 40000,
                Currency = "EUR",
                Id = new Guid("5a84a4ae11fb4160b0e9abd936dcb6bd"),
                CanClose = true,
                CanWithdraw = true
            });

            Accounts.Add(new Account()
            {
                Name = "Basic Savings",
                IBAN = "RSTB01ABC89ABCDEQ",
                Amount = 100000,
                Currency = "EUR",
                Id = new Guid("73f8b9a781f3477893a11b6bc6c8c06c")
            });

            DailyPolicy = new DailyPolicy();
        }

        public static ICollection<Account> Accounts { get; private set; }
        public static DailyPolicy DailyPolicy { get; private set; }
    }
}
