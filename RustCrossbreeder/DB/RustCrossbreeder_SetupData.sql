--Create and Configure Rust Crossbreeder Database

--Created: 8/13/2020 - MW
--Last Updated:

--Use RustCrossbreeder Database
USE [RustCrossbreeder];

GO

SET NOCOUNT ON

-----------------------------------------------
-- Configure Seed Types
-----------------------------------------------

-- Create a temp table for seed types
SELECT TOP 0 [SeedTypeId], [Name], [BaseGrowth], [BaseYield], [BaseWaterNeed], [BaseHardiness]
INTO #SeedTypesTemp
FROM [dbo].[SeedTypes]

INSERT INTO #SeedTypesTemp VALUES (1, 'Hemp', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (2, 'Pumpkin', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (3, 'Potato', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (4, 'Corn', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (5, 'BlueBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (6, 'RedBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (7, 'YellowBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (8, 'GreenBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (9, 'WhiteBerry', 1, 1, 5, 1)

-- Compare the old/new seed types and add any new ones (but do not edit existing values)
INSERT INTO [dbo].[SeedTypes] ([SeedTypeId], [Name], [BaseGrowth], [BaseYield], [BaseWaterNeed], [BaseHardiness])
SELECT [NEW].[SeedTypeId], [NEW].[Name], [NEW].[BaseGrowth], [NEW].[BaseYield], [NEW].[BaseWaterNeed], [NEW].[BaseHardiness]
FROM #SeedTypesTemp AS [NEW]
	LEFT JOIN [dbo].[SeedTypes] AS [EXISTING]
	ON [NEW].[Name] = [EXISTING].[Name]
WHERE [EXISTING].[Name] IS NULL