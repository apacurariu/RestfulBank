using System.Collections.Generic;

namespace RestfulBank.API.Resources
{
    public abstract class Resource
    {
        public Resource()
        {
            Links = new List<Link>();
        }

        public ICollection<Link> Links { get; private set; }

        public abstract string GetMediaType(); //test
    }
}
