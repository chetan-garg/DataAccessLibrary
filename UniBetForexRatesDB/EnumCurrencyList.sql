﻿CREATE TABLE [dbo].[EnumCurrencyList]
(
	[CurrencyId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CurrencyName] VARCHAR(200) NOT NULL UNIQUE
)
