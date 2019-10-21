/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @tempList TABLE(Currency Varchar(20))

INSERT INTO @tempList
	VALUES ('AUD'),
	('SEK'),
	('GBP'),
	('EUR'),
	('USD')


INSERT INTO EnumCurrencyList 
SELECT Currency FROM @tempList TL
LEFT OUTER JOIN EnumCurrencyList  ECL ON ECL.CurrencyName = TL.Currency
WHERE ECL.CurrencyName IS NULL