using System;
using System.Text;
using Unibet.DataEntities;

namespace Utilities
{
    public static class Utilities
    {
        public static string GenerateUrlWithCurrencySymbols(string baseUri, string apiKey)
        {
            StringBuilder builder = new StringBuilder();
            var enumValues = Enum.GetValues(typeof(EnumCurrencyList));

            foreach (var item in enumValues)
            {
                builder.AppendFormat("{0},", item.ToString());
            }

            return string.Format("{0}?accessKey{1}&symbols={2}&Format=1", baseUri, apiKey, builder.ToString());
        }
    }
}
