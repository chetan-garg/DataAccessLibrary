using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Unibet.DataEntities;
using Unibet.InterfaceLibrary;
using Utilities;

namespace GetRatesWorker
{
    public class GetRatesWorker : IGetRatesWorker
    {
        IDataHandler _dataHandler = null;
        IRatesConverter _converter = null;

        public GetRatesWorker(IDataHandler dataHandler, IRatesConverter converter)
        {
            _dataHandler = dataHandler;
            _converter = converter;
        }


        public void RefreshRatesFromApiAsync(string apiBaseUrl, string apiKey)
        {
            string apiUrl = Utilities.Utilities.GenerateUrlWithCurrencySymbols(apiBaseUrl, apiKey);
            if (!string.IsNullOrWhiteSpace(apiUrl))
            {
                List<CurrencyRates> rates = _dataHandler.GetExchangeRate(Enum.GetName(typeof(EnumCurrencyList), EnumCurrencyList.AUD), Enum.GetName(typeof(EnumCurrencyList), EnumCurrencyList.EUR));

                if (rates == null || rates.Where(x => x.Timestamp >= DateTime.Now.Date).Count() <= 0)
                {
                    var handler = new HttpClientHandler();
                    handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

                    HttpClient client = new HttpClient(handler);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string output = response.Content.ReadAsStringAsync().Result;
                        Rootobject converter = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(output);

                        var currencyRates = _converter.GetRatesFromJson(converter);
                        _dataHandler.AddExchangeRates(currencyRates);

                    }
                    else
                    {
                        throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.StatusCode));
                    }
                }

            }
        }
    }
}
