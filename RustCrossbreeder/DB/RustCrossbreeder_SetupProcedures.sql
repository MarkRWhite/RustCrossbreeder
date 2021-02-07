--Create and Configure RustCrossbreeder Stored Procedures

--Created: 8/15/2020 - MW
--Last Updated:

--Use RustCrossbreeder Database
USE [RustCrossbreeder];

GO

SET NOCOUNT ON

-- Drop Procedures to recreate
IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_GetSeeds') BEGIN
	DROP PROCEDURE [dbo].[usp_GetSeeds]
END

GO

-- Drop Procedures to recreate
IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_AddSeed') BEGIN
	DROP PROCEDURE [dbo].[usp_AddSeed]
END

GO

IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_UpdateSeed') BEGIN
	DROP PROCEDURE [dbo].[usp_UpdateSeed]
END

GO

IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_DeleteSeed') BEGIN
	DROP PROCEDURE [dbo].[usp_DeleteSeed]
END

GO

IF EXISTS (SELECT [name] FROM [sys].[types] WHERE [is_table_type] = 1 AND [name] = 'SeedTableType') BEGIN
	DROP TYPE SeedTableType
END

GO

IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_GetCatalogs') BEGIN
	DROP PROCEDURE [dbo].[usp_GetCatalogs]
END

GO

IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_CreateCatalog') BEGIN
	DROP PROCEDURE [dbo].[usp_CreateCatalog]
END

GO

IF EXISTS (SELECT [ROUTINE_NAME] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [ROUTINE_CATALOG] LIKE 'RustCrossbreeder' AND [ROUTINE_NAME] LIKE 'usp_DeleteCatalog') BEGIN
	DROP PROCEDURE [dbo].[usp_DeleteCatalog]
END

GO

CREATE TYPE SeedTableType AS TABLE (
	[SeedId] int NOT NULL
);

GO

-- Create usp_GetSeeds
CREATE PROCEDURE [dbo].[usp_GetSeeds]
	@SeedType int, 
	@CatalogId int
AS
BEGIN
	-- Return all Seeds
	SELECT [SeedId], [Traits], [SeedType], [CatalogId], [Generation], [Probability], [Created]
	FROM [dbo].[Seeds]
	WHERE [CatalogId] = @CatalogId
	AND [SeedType] = @SeedType
END
GO

GO

-- Create usp_AddSeed
CREATE PROCEDURE [dbo].[usp_AddSeed]
	@Traits varchar(6), 
	@SeedType int,
	@CatalogId int,
	@Generation int,
	@Parents SeedTableType READONLY,
	@Probability dec(10,7),

	@ReturnStatus int output,
	@ErrorMessage varchar(4000) output
AS
BEGIN
	SET @ReturnStatus = 0

	-- Check if seed exists already
	DECLARE @tempId int
	DECLARE @tempProb dec(10,7)
	
	BEGIN TRY

		-- Check if Seed exists
		IF EXISTS (
			SELECT [SeedId] = @tempId
				, [Probability] = @tempProb
			FROM [dbo].[Seeds]
			WHERE [Traits] = @Traits
			AND [SeedType] = @SeedType
			AND [CatalogId] = @CatalogId
		)
		BEGIN
			IF (@tempProb >= @Probability)
			BEGIN
				SET @ReturnStatus = 1; RETURN -- Seed already exists with higher probability
			END
			ELSE
			BEGIN
				-- Update Existing Seed
				UPDATE [dbo].[Seeds]
				SET [Generation] = @Generation, [Probability] = @Probability, [Created] = GETDATE()
				WHERE [SeedId] = @tempId

				-- Delete Previous parents
				DELETE FROM [dbo].[SeedRelationships]
				WHERE [SeedId] = @tempId

				-- Create Seed Parent Relationships
				INSERT INTO [dbo].[SeedRelationships]
				SELECT @tempId, [P].[SeedId]
				FROM @Parents AS [P]

				SET @ReturnStatus = 2; RETURN -- Existing Seed Updated
			END
		END

		-- Add a new Seed
		INSERT INTO [dbo].[Seeds] ([Traits], [SeedType], [CatalogId], [Generation], [Probability], [Created] )
		VALUES (@Traits, @SeedType, @CatalogId, @Generation, @Probability, GETDATE())

		-- Create Seed Parent Relationships
		INSERT INTO [dbo].[SeedRelationships]
		SELECT SCOPE_IDENTITY(), [P].[SeedId]
		FROM @Parents AS [P]
	
	END TRY
	BEGIN CATCH
		SET @ReturnStatus = 3;
		SET @ErrorMessage = ERROR_MESSAGE();
		RETURN;
	END CATCH;

END

GO

-- Update Seed
CREATE PROCEDURE [dbo].[usp_UpdateSeed]
	@SeedId int,
	@Traits varchar(6), 
	@SeedType int,
	@CatalogId int,
	@Generation int,
	@Parents SeedTableType READONLY,
	@Probability dec(10,7),

	@ReturnStatus int output,
	@ErrorMessage varchar(4000) output
AS
BEGIN
	SET @ReturnStatus = 0

	BEGIN TRY

		-- Check if Seed exists
		IF NOT EXISTS (
			SELECT [SeedId]
			FROM [dbo].[Seeds]
			WHERE [SeedId] = @SeedId
		)
		BEGIN
			SET @ReturnStatus = 1; RETURN -- Seed not found in database
		END

		BEGIN TRANSACTION

		-- Update Seed
		UPDATE [dbo].[Seeds]
		SET [Traits] = @Traits
			, [SeedType] = @SeedType
			, [CatalogId] = @CatalogId
			, [Generation] = @Generation
			, [Probability] = @Probability
		WHERE [SeedId] = @SeedId

		-- Delete Parents
		DELETE FROM [dbo].[SeedRelationships]
		WHERE [SeedId] = @SeedId

		-- Create Seed Parent Relationships
		INSERT INTO [dbo].[SeedRelationships]
		SELECT @SeedId, [P].[SeedId]
		FROM @Parents AS [P]

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @ReturnStatus = 3;
		SET @ErrorMessage = ERROR_MESSAGE();
		RETURN;
	END CATCH

END

GO

-- Delete Seed
CREATE PROCEDURE [dbo].[usp_DeleteSeed]
	@SeedId int, 

	@ReturnStatus int output,
	@ErrorMessage varchar(4000) output
AS
BEGIN
	SET @ReturnStatus = 0

	BEGIN TRY

		BEGIN TRANSACTION

		-- Delete Seed
		DELETE FROM [dbo].[Seeds]
		WHERE [SeedId] = @SeedId

		-- Delete Associated Parent Relationships
		DELETE FROM [dbo].[SeedRelationships]
		WHERE [SeedId] = @SeedId

		COMMIT TRANSACTION
	
	END TRY
	BEGIN CATCH
		SET @ReturnStatus = 3;
		SET @ErrorMessage = ERROR_MESSAGE();
		RETURN;
	END CATCH
	
END

GO

-- Create usp_GetCatalogs
CREATE PROCEDURE [dbo].[usp_GetCatalogs]
AS
BEGIN
	-- Return all catalogs
	SELECT [CatalogId], [Name]
	FROM [dbo].[Catalogs]
END

GO

-- Create usp_CreateCatalog
CREATE PROCEDURE [dbo].[usp_CreateCatalog]
	@Name varchar(100), 

	@ReturnStatus int output,
	@ErrorMessage varchar(4000) output
AS
BEGIN
	SET @ReturnStatus = 0

	BEGIN TRY
		BEGIN TRANSACTION;

		-- Check if Catalog exists
		IF NOT EXISTS (
			SELECT [Name]
			FROM [dbo].[Catalogs]
			WHERE [Name] = @Name
		)
		BEGIN
			INSERT INTO [dbo].[Catalogs]([Name]) VALUES (@Name)
		END
		ELSE
		BEGIN
			SET @ReturnStatus = 4
		END	
		
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		SET @ReturnStatus = 3;
		SET @ErrorMessage = ERROR_MESSAGE();
		RETURN;
	END CATCH;

END

GO

-- Create usp_DeleteCatalog
CREATE PROCEDURE [dbo].[usp_DeleteCatalog]
	@Name varchar(100), 

	@ReturnStatus int output,
	@ErrorMessage varchar(4000) output
AS
BEGIN
	SET @ReturnStatus = 0

	BEGIN TRY
		BEGIN TRANSACTION;

		-- Check if Catalog exists
		IF NOT EXISTS (
			SELECT [Name]
			FROM [dbo].[Catalogs]
			WHERE [Name] = @Name
		)
		BEGIN
			SET @ReturnStatus = 5; RETURN
		END
			
		DELETE FROM [dbo].[Catalogs]
		WHERE [Name] = @Name
		
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		SET @ReturnStatus = 3;
		SET @ErrorMessage = ERROR_MESSAGE();
		RETURN;
	END CATCH;

END