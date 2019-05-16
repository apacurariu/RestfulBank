namespace RestfulBank.API.Resources
{
    public class Withdrawal : Resource
    {
        public double Amount { get; set; }

        public override string GetMediaType()
        {
            return "application/vnd.restfulbank.withdrawal+json";
        }
    }
}
