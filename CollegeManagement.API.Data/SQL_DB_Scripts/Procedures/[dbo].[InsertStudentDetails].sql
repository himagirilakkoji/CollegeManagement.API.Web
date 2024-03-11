USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertStudentDetails]    Script Date: 11-03-2024 15:01:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Description:
    This procedure will Insert StudentDetails .

Affected tables:
    [dbo].[Student];
    [dbo].[StudentCourse];
    [dbo].[StudentSubject];

High-level flow:
     01.Insert Student data with courses,subjects into corresponding tables 
*/


ALTER PROCEDURE [dbo].[InsertStudentDetails]
    @InputAsJSON NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Null AS VARCHAR(10) = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;
		DECLARE @StudentID INT;
        DECLARE @FacultyID UNIQUEIDENTIFIER;
        DECLARE @BranchID INT;

        INSERT INTO Student (FirstName, LastName,UserName, Email, [Password])
        SELECT [FirstName], [LastName],[UserName], [Email], [Password]
        FROM OPENJSON(@InputAsJSON)
        WITH (
            [FirstName] VARCHAR(100),
            [LastName] VARCHAR(100),
			[UserName] VARCHAR(100),
            [Email] VARCHAR(100),
            [Password] VARCHAR(100)
        );
		-- Get the ID of the inserted student
		SET @StudentID = (SELECT TOP 1 StudentID FROM [dbo].[Student] WHERE  Email = JSON_VALUE(@InputAsJSON, '$.Email'));

        -- Get the FacultyID and BranchID based on the provided FacultyName and Branch
        SET @FacultyID = (SELECT TOP 1 FacultyID FROM Faculty WHERE Dept = JSON_VALUE(@InputAsJSON, '$.Branch') AND UserName = JSON_VALUE(@InputAsJSON, '$.Faculty'));
        SET @BranchID = (SELECT TOP 1 DeptID FROM Department WHERE Name = JSON_VALUE(@InputAsJSON, '$.Branch'));

        -- Insert into StudentCourse
        INSERT INTO StudentCourse (StudentID, CourseID, BranchName, FacultyID)
        SELECT @StudentID, c.CourseID, d.Name, @FacultyID
        FROM Course c
        INNER JOIN Department d ON c.DeptID = d.DeptID
        WHERE c.DeptID = @BranchID;

        -- Insert into StudentSubject
        INSERT INTO StudentSubject (SubjectName,StudentID, CourseID, FacultyID, BranchName)
        SELECT s.Name,@StudentID, c.CourseID, @FacultyID, d.Name
        FROM Subject s
        INNER JOIN Course c ON s.CourseID = c.CourseID
        INNER JOIN Department d ON c.DeptID = d.DeptID
        WHERE c.DeptID = @BranchID;

        COMMIT TRANSACTION;

        SET @Response = 'Success';

        SELECT @Null AS [ErrorProcedure], 
		@Response AS [Response];

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT
		ERROR_MESSAGE() AS [ErrorProcedure], 
		@Response AS [Response];
    END CATCH
END;
