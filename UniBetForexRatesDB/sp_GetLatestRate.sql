CREATE PROCEDURE [dbo].[sp_GetLatestRate]
	@baseCurrency VARCHAR(50),
	@targetCurrency VARCHAR(50)
AS
BEGIN
	SELECT TOP 1 Base.CurrencyName [BaseCurrency], Trgt.CurrencyName [TargetCurrency], Rates.ConversionRate, Timestamp 
	FROM CurrencyRates Rates (NOLOCK)
	INNER JOIN EnumCurrencyList Base ON Base.CurrencyId = Rates.BaseCurrencyId
	INNER JOIN EnumCurrencyList Trgt ON Trgt.CurrencyId = Rates.DestinationCurrencyId
	WHERE Base.CurrencyName = @baseCurrency AND Trgt.CurrencyName = @targetCurrency
	ORDER BY Timestamp DESC
END