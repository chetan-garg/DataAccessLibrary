using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Unibet.DataEntities
{
    public class CurrencyRates

    {
        [Required]
        public EnumCurrencyList BaseCurrency { get; set; }
        [Required]
        public EnumCurrencyList TargetCurrency { get; set; }
        
        [DisplayFormat(DataFormatString = "0:0.00000")]
        public double ConversionRate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
