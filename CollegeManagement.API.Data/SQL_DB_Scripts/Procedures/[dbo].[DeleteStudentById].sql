USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentById]    Script Date: 15-03-2024 00:39:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will delete the current Student by StudentById.

Called from:
	[dbo].[StudentSubject] ,
	[dbo].[StudentCourse] ,
	[dbo].[Student],
	[dbo].[ExamMarks]

High-level flow:
     01.Base on Id we will delete the records from these tables [dbo].[StudentSubject] ,[dbo].[StudentCourse] ,[dbo].[Student]
*/



ALTER PROCEDURE [dbo].[DeleteStudentById]
    @StudentId INT
AS
BEGIN

	DECLARE @Null           AS VARCHAR       = NULL;
	DECLARE @Response		AS VARCHAR(MAX)  = NULL               -- Get Response

    BEGIN TRY
        -- Check if the faculty exists
        IF EXISTS (SELECT 1 FROM [dbo].[Student] WHERE StudentID = @StudentId)
        BEGIN
		    BEGIN TRANSACTION;

			-- Delete from ExamMarks table
            DELETE FROM [dbo].[ExamMarks]  WHERE StudentID = @StudentId;

            -- Delete from FacultySubject table
            DELETE FROM [dbo].[StudentSubject]  WHERE StudentID = @StudentId;

            -- Delete from FacultyCourse table
            DELETE FROM [dbo].[StudentCourse]   WHERE StudentID = @StudentId;

            -- Delete from Faculty table
            DELETE FROM [dbo].[Student]         WHERE StudentID = @StudentId;

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
