USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[UserLoginValidations]    Script Date: 04-03-2024 16:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will carry the validations login User.

Called from:
	[dbo].[Admin]

High-level flow:
     01.Validate given EmailId and Password with respective in [dbo].[Admin].[EmailId] and [dbo].[Admin].[Password] 
*/



ALTER PROCEDURE [dbo].[UserLoginValidations]
    @EmailId    NVARCHAR(100),
    @Password   NVARCHAR(100)
AS
BEGIN

    DECLARE @UserEmailId    AS NVARCHAR(100);
	DECLARE @Null		    AS VARCHAR = NULL;	

	-- Response codes to be returned from this procedure
	DECLARE @AuthorizedCode						AS VARCHAR(15)  = 'AUTHORIZED'        -- AUTHORIZED status code
	DECLARE @ErrorCode           				AS VARCHAR(15)  = 'ERROR'             -- ErrorCode in Store Procedure
	DECLARE @Response					        AS VARCHAR(MAX)  = NULL               -- Get Responce

    BEGIN TRY
        -- Check if the username and password match
        SELECT @UserEmailId = a.[Email]
        FROM [dbo].[Admin] a
        WHERE a.[Email] = @EmailID
        AND a.[PasswordHash] = CONVERT([varchar](256), HASHBYTES('SHA2_256', @Password), 2)
 
        -- If a matching user is found, return success message
		IF (@UserEmailId IS NOT NULL)
		BEGIN
		    SET @Response = (SELECT * FROM [dbo].[Admin] a
			                 INNER JOIN  [dbo].[Roles] r
			                         ON a.AdminRoleID = r.RoleID
			                 WHERE a.[Email] = @UserEmailId FOR JSON PATH,WITHOUT_ARRAY_WRAPPER)
			SELECT 
				@AuthorizedCode		   AS [ResponseCode],
				@Null				   AS [ErrorProcedure],
				@Response              AS [Response]
		END

		-- If a matching user is found, return success message
		IF (@UserEmailId IS NULL)
		BEGIN
		    SET @AuthorizedCode = 'NOTFOUND';
			SELECT
				@AuthorizedCode	       AS [ResponseCode],
				@Null				   AS [ErrorProcedure],
				@Response              AS [Response]
		END

    END TRY
    BEGIN CATCH
            SELECT 
				@Null	               AS [ResponseCode],
				ERROR_MESSAGE()	       AS [ErrorProcedure],
				@Response              AS [Response]
    END CATCH
END
