--Create and Configure RustCrossbreeder Schema

--Created: 2020/08/13 - MW
--Last Updated: 

USE [master]

GO

SET NOCOUNT ON

--Create RustCrossbreeder Database
IF NOT EXISTS (SELECT [name] FROM [sys].[databases] WHERE [name] LIKE 'RustCrossbreeder')
	CREATE DATABASE [RustCrossbreeder];

GO

--Use RustCrossbreeder Database
USE [RustCrossbreeder];

GO

-----------------------------------------------
--Create Seeds Table
-----------------------------------------------

-- Create Seeds Table
IF NOT EXISTS (SELECT [TABLE_NAME] FROM [INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_CATALOG] LIKE 'RustCrossbreeder' AND [TABLE_NAME] LIKE 'Seeds')
CREATE TABLE [RustCrossbreeder].[dbo].[Seeds] (
	[SeedId] int NOT NULL IDENTITY(1,1),
	[Traits] varchar(6) NOT NULL,
	[SeedType] int NOT NULL,
	[CatalogId] int NOT NULL,
	[Generation] int NOT NULL,
	[Probability] dec(10,7) NOT NULL,
	[Created] datetime NULL,
	PRIMARY KEY ([SeedId])
);

GO

-- Create SeedTypes Table
IF NOT EXISTS (SELECT [TABLE_NAME] FROM [INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_CATALOG] LIKE 'RustCrossbreeder' AND [TABLE_NAME] LIKE 'SeedTypes')
CREATE TABLE [RustCrossbreeder].[dbo].[SeedTypes] (
	[SeedTypeId] int NOT NULL,
	[Name] nvarchar(32) NOT NULL,
	[BaseGrowth] dec(10,7) NOT NULL,
	[BaseYield] dec(10,7) NOT NULL,
	[BaseWaterNeed] dec(10,7) NOT NULL,
	[BaseHardiness] dec(10,7) NOT NULL,
	PRIMARY KEY ([SeedTypeId])
);

GO

-- Create SeedRelationships Table
IF NOT EXISTS (SELECT [TABLE_NAME] FROM [INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_CATALOG] LIKE 'RustCrossbreeder' AND [TABLE_NAME] LIKE 'SeedRelationships')
CREATE TABLE [RustCrossbreeder].[dbo].[SeedRelationships] (
	[SeedRelationshipId] int NOT NULL IDENTITY(1,1),
	[SeedId] int NOT NULL,
	[ParentSeedId] int NOT NULL,
	PRIMARY KEY ([SeedRelationshipId])
);