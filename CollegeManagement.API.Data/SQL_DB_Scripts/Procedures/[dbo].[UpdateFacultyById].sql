USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateFacultyById]    Script Date: 09-03-2024 23:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Description:
	This procedure will Update FacultyDetails .

Affected tables:
    [dbo].[Faculty];
	[dbo].[FacultyCourse];
	[dbo].[FacultySubject];

High-level flow:
     01.Update faculty data with courses,subjects into corresponding tables 
*/



ALTER PROCEDURE [dbo].[UpdateFacultyById]
    @FacultyGuid UNIQUEIDENTIFIER,
    @UpdateInputAsJSON NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Null AS VARCHAR = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update Faculty data
        UPDATE Faculty
        SET
            FirstName = JSON_VALUE(@UpdateInputAsJSON, '$.FirstName'),
            LastName = JSON_VALUE(@UpdateInputAsJSON, '$.LastName'),
            UserName = JSON_VALUE(@UpdateInputAsJSON, '$.UserName'),
            Email = JSON_VALUE(@UpdateInputAsJSON, '$.Email'),
            Dept = JSON_VALUE(@UpdateInputAsJSON, '$.Dept')
        WHERE
            FacultyID = @FacultyGuid;

        -- Update FacultyCourse data
        DELETE FROM FacultyCourse WHERE FacultyID = @FacultyGuid;
        INSERT INTO FacultyCourse (CourseName, FacultyID, Dept)
        SELECT
            [CourseName],
            @FacultyGuid,
            JSON_VALUE(@UpdateInputAsJSON, '$.Dept')
        FROM OPENJSON(@UpdateInputAsJSON, '$.courseRequests')
        WITH (
            [Dept] VARCHAR(100) '$.Dept',
            [CourseName] VARCHAR(100) '$.CourseName'
        );

        -- Update FacultySubject data
        DELETE FROM FacultySubject WHERE FacultyID = @FacultyGuid;
        INSERT INTO FacultySubject (SubjectName, FacultyID, CourseName)
        SELECT
            [SubjectName],
            @FacultyGuid,
            [CourseName]
        FROM OPENJSON(@UpdateInputAsJSON, '$.subjectRequests')
        WITH (
            [CourseName] VARCHAR(100) '$.CourseName',
            [SubjectName] VARCHAR(100) '$.SubjectName'
        );

        COMMIT TRANSACTION;

        SET @Response = 'Success';

        SELECT
            @Null AS [ErrorProcedure],
            @Response AS [Response];

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT
            @Null AS [ErrorProcedure],
            ERROR_MESSAGE() AS [Response];
    END CATCH
END;
