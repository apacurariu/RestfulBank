using RestfulBank.API.Model;

namespace RestfulBank.API.ApplicationServices
{
    public interface IOverviewProvider
    {
        Overview GetOverview();
    }
}