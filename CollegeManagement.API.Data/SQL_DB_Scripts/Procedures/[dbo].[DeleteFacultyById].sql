USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFacultyById]    Script Date: 15-03-2024 00:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will delete the current faculty by facultyGuid.

Called from:
	[dbo].[FacultySubject] ,
	[dbo].[FacultyCourse] ,
	[dbo].[Faculty],
	[dbo].[StudentSubject],
	[dbo].[StudentCourse]

High-level flow:
     01.Base on Guid we will delete the records from these tables [dbo].[FacultySubject] ,[dbo].[FacultyCourse] ,[dbo].[Faculty]
*/



ALTER PROCEDURE [dbo].[DeleteFacultyById]
    @FacultyId UNIQUEIDENTIFIER
AS
BEGIN

	DECLARE @Null           AS VARCHAR       = NULL;
	DECLARE @Response		AS VARCHAR(MAX)  = NULL               -- Get Response

    BEGIN TRY
        -- Check if the faculty exists
        IF EXISTS (SELECT 1 FROM [dbo].[Faculty] WHERE FacultyID = @FacultyId)
        BEGIN
		    BEGIN TRANSACTION;

			-- Delete from StudentSubject table
			DELETE FROM [dbo].[StudentSubject]  WHERE FacultyID = @FacultyId;

			-- Delete from StudentCourse table
			DELETE FROM [dbo].[StudentCourse]   WHERE FacultyID = @FacultyId;

            -- Delete from FacultySubject table
            DELETE FROM [dbo].[FacultySubject]  WHERE FacultyID = @FacultyId;

            -- Delete from FacultyCourse table
            DELETE FROM [dbo].[FacultyCourse]   WHERE FacultyID = @FacultyId;

            -- Delete from Faculty table
            DELETE FROM [dbo].[Faculty]         WHERE FacultyID = @FacultyId;

            COMMIT TRANSACTION;

            SET @Response = 'Success';
        END
        ELSE
        BEGIN
            SET @Response = 'Faculty does not exist';
        END

		SELECT
            @Null      AS [ErrorProcedure],
            @Response  AS [Response]

    END TRY

    BEGIN CATCH
	        ROLLBACK TRANSACTION;
            SELECT 
				ERROR_MESSAGE()	       AS [ErrorProcedure],
				@Response              AS [Response]
    END CATCH
END
