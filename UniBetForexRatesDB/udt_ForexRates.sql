CREATE TYPE [dbo].[udt_ForexRates] AS TABLE
(
	BaseCurrency varchar(50), TargetCurrency varchar(50), ExchangeRate DECIMAL(20,5)
)
