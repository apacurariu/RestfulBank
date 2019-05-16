namespace RestfulBank.API.Resources
{
    public abstract class ProblemDetails : MediaType
    {
        public string Type { get; set; }
        public string Instance { get; set; }
        public string Detail { get; set; }
    }
}
