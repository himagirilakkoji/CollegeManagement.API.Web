USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertFacultyDetails]    Script Date: 06-03-2024 15:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Description:
	This procedure will Insert FacultyDetails .

Affected tables:
    [dbo].[Faculty];
	[dbo].[FacultyCourse];
	[dbo].[FacultySubject];

High-level flow:
     01.Insert faculty data with courses,subjects into corresponding tables 
*/


ALTER PROCEDURE [dbo].[InsertFacultyDetails]
    @InputAsJSON NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Null     AS VARCHAR = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL; -- Get Response
    DECLARE @Guid     AS VARCHAR(MAX) = NULL;

    BEGIN TRY
	    BEGIN TRANSACTION;

	    SET @Guid = NEWID();
		-- Insert Faculty data
		INSERT INTO Faculty
		SELECT
		    @Guid,
			[FirstName],
			[LastName],
			[UserName],
			[Email],
			[Password],
			[Dept]
		FROM OPENJSON(@InputAsJSON)
		WITH (
			[FirstName]      VARCHAR(100)       '$.FirstName',
			[LastName]       VARCHAR(100)       '$.LastName',
			[UserName]       VARCHAR(100)       '$.UserName',
			[Email]          VARCHAR(100)       '$.Email',
			[Password]       VARCHAR(100)       '$.Password',
			[Dept]           VARCHAR(100)       '$.Dept'
		);

		-- Insert FacultyCourse data
		INSERT INTO FacultyCourse
		SELECT
			[CourseName],
			@Guid,
			[Dept]
		FROM OPENJSON(@InputAsJSON,'$.courseRequests')
		WITH (
		    [Dept]      VARCHAR(100)              '$.Dept',
			[CourseName]      VARCHAR(100)        '$.CourseName'
		);

		-- Insert FacultySubject data
		INSERT INTO FacultySubject
		SELECT
			[SubjectName],
			@Guid,
			[CourseName]
		FROM OPENJSON(@InputAsJSON,'$.subjectRequests')
		WITH (
		    [CourseName]      VARCHAR(100)        '$.CourseName',
			[SubjectName]      VARCHAR(100)        '$.SubjectName'
		);
        
		COMMIT TRANSACTION;

		SET @Response = 'Success';

        SELECT
            @Null      AS [ErrorProcedure],
            @Response  AS [Response]
 
    END TRY
    BEGIN CATCH
	    ROLLBACK TRANSACTION;
        SELECT
            @Null AS [ResponseCode],
            ERROR_MESSAGE() AS [ErrorProcedure],
            @Response AS [Response];
    END CATCH
END;