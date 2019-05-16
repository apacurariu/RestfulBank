namespace RestfulBank.API.Resources
{
    public abstract class ProblemDetails : Resource
    {
        public ProblemDetails(string type)
        {
            Type = type;
        }

        public string Type { get; set; }
        public string Instance { get; set; }
        public string Detail { get; set; }
    }
}
