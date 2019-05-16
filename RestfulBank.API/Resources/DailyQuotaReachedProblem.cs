namespace RestfulBank.API.Resources
{
    public class DailyQuotaReachedProblem : ProblemDetails
    {
        public DailyQuotaReachedProblem(double dailyLimit)
        {
            DailyLimit = dailyLimit;
            Detail = $"Unfortunately you would exceed your daily transfer/withdrawal quota of {dailyLimit} EUR.";
        }

        public double DailyLimit { get; set; }
    }
}
