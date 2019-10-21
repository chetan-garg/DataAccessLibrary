using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniBetFXApi
{
    public class FxRateRequest
    {
        [Required]
        public string baseCurrency { get; set; }
        [Required]
        public string targetCurrency { get; set; }

    }
}
