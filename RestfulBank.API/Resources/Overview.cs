using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulBank.API.Resources
{
    public class Overview : Resource<Model.Overview>
    {
        public Overview(string basePath, Model.Overview model) 
            : base(basePath, model)
        {
            Accounts = new List<Account>(model.Accounts.Select(a => new Account(basePath, a)));

            AddSelf();
            AddLink("transfers", "transfers");
        }

        public ICollection<Account> Accounts { get; private set; }
    }
}
