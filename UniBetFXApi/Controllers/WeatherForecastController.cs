using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UniBetFXApi.Controllers
{
    [ApiController]
    [Route("[Unitbet]")]
    public class UnibetFxController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UnibetFxController> _logger;

        public UnibetFxController(ILogger<UnibetFxController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FxRate> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FxRate
            {
                Date = DateTime.Now.AddDays(index),
                
            })
            .ToArray();
        }
    }
}
