CREATE TABLE [dbo].[EnumCurrencyList]
(
	[CurrencyId] INT NOT NULL PRIMARY KEY,
	[CurrencyName] VARCHAR(200) NOT NULL UNIQUE
)
