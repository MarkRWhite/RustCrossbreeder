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

INSERT INTO #SeedTypesTemp VALUES (0, 'Hemp', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (1, 'Pumpkin', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (2, 'Potato', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (3, 'Corn', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (4, 'BlueBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (5, 'RedBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (6, 'YellowBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (7, 'GreenBerry', 1, 1, 5, 1)
INSERT INTO #SeedTypesTemp VALUES (8, 'WhiteBerry', 1, 1, 5, 1)

-- Compare the old/new seed types and add any new ones (but do not edit existing values)
INSERT INTO [dbo].[SeedTypes] ([SeedTypeId], [Name], [BaseGrowth], [BaseYield], [BaseWaterNeed], [BaseHardiness])
SELECT [NEW].[SeedTypeId], [NEW].[Name], [NEW].[BaseGrowth], [NEW].[BaseYield], [NEW].[BaseWaterNeed], [NEW].[BaseHardiness]
FROM #SeedTypesTemp AS [NEW]
	LEFT JOIN [dbo].[SeedTypes] AS [EXISTING]
	ON [NEW].[Name] = [EXISTING].[Name]
WHERE [EXISTING].[Name] IS NULL