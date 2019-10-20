using System;
using System.Collections.Generic;
using System.Text;
using Unibet.DataEntities;
using Unibet.InterfaceLibrary;

namespace Orchestration
{
    public class RatesConverter : IRatesConverter
    {
        public List<CurrencyRates> GetRatesFromJson(Rootobject jsonResponse)
        {
            List<CurrencyRates> currencyRates = new List<CurrencyRates>();

            if (jsonResponse != null)
            {
                double audVsEur = jsonResponse.rates.AUD;
                double gbpVsEUR = jsonResponse.rates.GBP;
                double sekVsEur = jsonResponse.rates.SEK;
                double usdVsEur = jsonResponse.rates.USD;
                
                var sourceCurrencyList = Enum.GetValues(typeof(EnumCurrencyList));
                var destCurrencyList = Enum.GetValues(typeof(EnumCurrencyList));

                foreach (var source in sourceCurrencyList)
                {
                    foreach (var dest in destCurrencyList)
                    {
                        if (source == dest)
                        {
                            continue;
                        }

                        switch ((EnumCurrencyList)source)
                        {
                            case EnumCurrencyList.AUD:
                                currencyRates.Add(GetAUDConversionRate((EnumCurrencyList)dest, audVsEur, jsonResponse.rates));
                                break;
                            case EnumCurrencyList.SEK:
                                currencyRates.Add(GetSEKConversionRate((EnumCurrencyList)dest, sekVsEur, jsonResponse.rates));
                                break;
                            case EnumCurrencyList.USD:
                                currencyRates.Add(GetUSDConversionRate((EnumCurrencyList)dest, usdVsEur, jsonResponse.rates));
                                break;
                            case EnumCurrencyList.GBP:
                                currencyRates.Add(GetGBPConversionRate((EnumCurrencyList)dest, gbpVsEUR, jsonResponse.rates));
                                break;
                            case EnumCurrencyList.EUR:
                                currencyRates.Add(GetAUDConversionRate((EnumCurrencyList)dest, 1, jsonResponse.rates));
                                break;
                        }
                    }
                }

                
            }
            return currencyRates;
        }

        private CurrencyRates GetGBPConversionRate(EnumCurrencyList dest, double gbpVsEUR, Rates rates)
        {
            double gbpRate = 1 / gbpVsEUR;

            switch (dest)
            {
                case EnumCurrencyList.AUD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.GBP,
                        TargetCurrency = EnumCurrencyList.AUD,
                        ConversionRate = (gbpRate * rates.AUD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.SEK:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.GBP,
                        TargetCurrency = EnumCurrencyList.SEK,
                        ConversionRate = (gbpRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.USD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.GBP,
                        TargetCurrency = EnumCurrencyList.USD,
                        ConversionRate = (gbpRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.EUR:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.GBP,
                        TargetCurrency = EnumCurrencyList.EUR,
                        ConversionRate = gbpRate,
                        Timestamp = DateTime.Now
                    };
            }
            return null;
        }

        private CurrencyRates GetAUDConversionRate(EnumCurrencyList dest, double rate, Rates rates)
        {
            double audRate = 1 / rate;

            switch (dest)
            {
                case EnumCurrencyList.SEK:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.AUD,
                        TargetCurrency = EnumCurrencyList.SEK,
                        ConversionRate = (audRate * rates.SEK),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.USD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.AUD,
                        TargetCurrency = EnumCurrencyList.USD,
                        ConversionRate = (audRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.GBP:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.AUD,
                        TargetCurrency = EnumCurrencyList.GBP,
                        ConversionRate = (audRate * rates.GBP),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.EUR:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.AUD,
                        TargetCurrency = EnumCurrencyList.EUR,
                        ConversionRate = audRate,
                        Timestamp = DateTime.Now
                    };
            }
            return null;
        }

        private CurrencyRates GetSEKConversionRate(EnumCurrencyList dest, double rate, Rates rates)
        {
            double sekRate = 1 / rate;

            switch (dest)
            {
                case EnumCurrencyList.AUD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.SEK,
                        TargetCurrency = EnumCurrencyList.AUD,
                        ConversionRate = (sekRate * rates.AUD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.USD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.SEK,
                        TargetCurrency = EnumCurrencyList.USD,
                        ConversionRate = (sekRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.GBP:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.SEK,
                        TargetCurrency = EnumCurrencyList.GBP,
                        ConversionRate = (sekRate * rates.GBP),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.EUR:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.SEK,
                        TargetCurrency = EnumCurrencyList.EUR,
                        ConversionRate = sekRate,
                        Timestamp = DateTime.Now
                    };
            }
            return null;
        }

        private CurrencyRates GetUSDConversionRate(EnumCurrencyList dest, double rate, Rates rates)
        {
            double usdRate = 1 / rate;

            switch (dest)
            {
                case EnumCurrencyList.AUD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.USD,
                        TargetCurrency = EnumCurrencyList.AUD,
                        ConversionRate = (usdRate * rates.AUD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.SEK:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.USD,
                        TargetCurrency = EnumCurrencyList.SEK,
                        ConversionRate = (usdRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.GBP:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.USD,
                        TargetCurrency = EnumCurrencyList.GBP,
                        ConversionRate = (usdRate * rates.GBP),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.EUR:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.USD,
                        TargetCurrency = EnumCurrencyList.EUR,
                        ConversionRate = usdRate,
                        Timestamp = DateTime.Now
                    };
            }
            return null;
        }

        private CurrencyRates GetEURConversionRate(EnumCurrencyList dest, double eurVsEUR, Rates rates)
        {
            double eurRate = 1 / eurVsEUR;

            switch (dest)
            {
                case EnumCurrencyList.AUD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.EUR,
                        TargetCurrency = EnumCurrencyList.AUD,
                        ConversionRate = (eurRate * rates.AUD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.SEK:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.EUR,
                        TargetCurrency = EnumCurrencyList.SEK,
                        ConversionRate = (eurRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.USD:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.EUR,
                        TargetCurrency = EnumCurrencyList.USD,
                        ConversionRate = (eurRate * rates.USD),
                        Timestamp = DateTime.Now
                    };
                case EnumCurrencyList.GBP:
                    return new CurrencyRates()
                    {
                        BaseCurrency = EnumCurrencyList.EUR,
                        TargetCurrency = EnumCurrencyList.GBP,
                        ConversionRate = eurRate,
                        Timestamp = DateTime.Now
                    };
            }
            return null;
        }
    }
}
