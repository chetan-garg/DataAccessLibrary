using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UniBetFXApi.Controllers
{
    [ApiController]
    [Route("Unibet")]
    public class UnibetFxController : ControllerBase
    {
        private readonly ILogger<UnibetFxController> _logger;

        public UnibetFxController(ILogger<UnibetFxController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<FxRate> Get([FromBody] FxRateRequest requestObject)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FxRate
            {
                Date = DateTime.Now.AddDays(index),
                BaseCurrency = requestObject.baseCurrency,
                TargetCurrency = requestObject.targetCurrency
            })
            .ToArray();
        }
    }
}
