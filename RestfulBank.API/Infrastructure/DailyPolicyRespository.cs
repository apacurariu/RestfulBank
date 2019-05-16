using RestfulBank.API.Domain;

namespace RestfulBank.API.Infrastructure
{
    public class DailyPolicyRespository : IDailyPolicyRespository
    {
        public DailyPolicy GetDailyPolicy()
        {
            return DB.DailyPolicy;
        }
    }
}
