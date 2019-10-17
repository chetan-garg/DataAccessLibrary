CREATE TABLE [dbo].[CurrencyRatesTable]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
	[BaseCurrencyId] INT NOT NULL REFERENCES [dbo].[EnumCurrencyList],
	[DestinationCurrencyId] INT NOT NULL REFERENCES [dbo].[EnumCurrencyList],
	[ConversionRate] DECIMAL NOT NULL,
	[Timestamp] DATETIME NOT NULL
)
