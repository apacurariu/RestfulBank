using System;
using Microsoft.AspNetCore.Mvc;
using RestfulBank.API.ApplicationServices;
using RestfulBank.API.Resources;

namespace RestfulBank.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class OverviewController : ControllerBase
    {
        private readonly IOverviewProvider _overviewProvider;

        public OverviewController(IOverviewProvider overviewProvider)
        {
            _overviewProvider = overviewProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var overview = ResourceFormatter.FormatOverview(_overviewProvider.GetOverview());

            return this.OkResource(overview);
        }
    }
}
