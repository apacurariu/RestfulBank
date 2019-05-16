using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class Overview : Resource
    {
        public Overview()
        {
            Accounts = new List<Account>();
        }

        public ICollection<Account> Accounts { get; private set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.overview+json";
        }
    }
}
