using System;
using System.Collections.Generic;
using System.IO;
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
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(apiBaseUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Rootobject> output = response.Content.ReadAsAsync<IEnumerable<Rootobject>>().Result;
                    foreach (var item in output)
                    {
                        var currencyRates = _converter.GetRatesFromJson(item);
                        _dataHandler.AddExchangeRates(currencyRates);
                    }
                    
                }
                else
                {
                    throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.StatusCode));
                }

            }
        }
    }
}
