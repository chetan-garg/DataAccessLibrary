CREATE PROCEDURE [dbo].[sp_AddRates]
	@fxRates udt_ForexRates READONLY
AS
BEGIN

	DECLARE @inputCount INT = (SELECT COUNT(1) FROM @fxRates);
	
	INSERT INTO CurrencyRates 
		(BaseCurrencyId, DestinationCurrencyId, ConversionRate, Timestamp)
	SELECT			
		Base.CurrencyId, Trgt.CurrencyId, newRates.ExchangeRate, GETDATE() 
	FROM 
		@fxRates newRates 
	INNER JOIN 
		EnumCurrencyList Base ON newRates.BaseCurrency = Base.CurrencyName
	INNER JOIN 
		EnumCurrencyList Trgt ON newRates.TargetCurrency = Trget.CurrencyName

	IF @@ROWCOUNT = @inputCount
		RETURN 1
	ELSE
		RETURN 0

END