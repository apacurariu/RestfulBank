using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Model
{
    public class Overview
    {
        public Overview()
        {
            Accounts = new List<Account>();
        }

        public ICollection<Account> Accounts { get; private set; }
    }
}
