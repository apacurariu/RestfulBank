﻿using System;
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
            return this.OkResource(new Overview("api", _overviewProvider.GetOverview()));
        }
    }
}
