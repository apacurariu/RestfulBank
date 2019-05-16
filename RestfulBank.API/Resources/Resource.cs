using System.Collections.Generic;

namespace RestfulBank.API.Resources
{
    public abstract class MediaType
    {
        public virtual string GetMediaType(string vendor, SerializationFormat serializationFormat = SerializationFormat.JSON)
        {
            return $"application/vnd.{vendor}.{GetMediaTypeName()}+{serializationFormat.ToString().ToLower()}";
        }

        public virtual string GetMediaTypeName()
        {
            return GetType().Name.ToLower();
        }
    }

    public abstract class Resource : MediaType
    {
        private readonly string _basePath;

        public Resource(string basePath)
        {
            Links = new List<Link>();
            _basePath = basePath;
        }

        public ICollection<Link> Links { get; private set; }

        public virtual void AddSelf()
        {
            AddSelf("");
        }
        public virtual void AddSelf(string url)
        {
            AddLink("self", url);
        }

        public virtual void AddLink(string rel, string url)
        {
            Links.Add(new Link()
            {
                Rel = rel,
                Url = $"/{_basePath}/{url}"
            });
        }
       
    }

    public abstract class Resource<TModel> : Resource
    {
        private readonly string _basePath;

        public Resource(string basePath, TModel model)
            : base(basePath)
        {
        }
    }
}
