namespace RestfulBank.API.Resources
{
    public class DailyQuotaReachedProblem : ProblemDetails
    {
        public DailyQuotaReachedProblem(string type, double dailyLimit)
            : base(type)
        {
            DailyLimit = dailyLimit;
            Detail = $"Unfortunately you would exceed your daily transfer/withdrawal quota of {dailyLimit} EUR.";
        }

        public double DailyLimit { get; set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.problems.dailyquotareached+json";
        }
    }
}
