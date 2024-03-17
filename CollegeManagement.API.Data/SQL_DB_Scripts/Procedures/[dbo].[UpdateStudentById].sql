USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentById]    Script Date: 18-03-2024 02:24:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Description:
	This procedure will Update StudentDetails .

Affected tables:
    [dbo].[Student];
	[dbo].[StudentCourse];
	[dbo].[StudentSubject];

High-level flow:
     01.Update Student data with courses,subjects into corresponding tables 
*/

--exec [dbo].[UpdateStudentById]
ALTER PROCEDURE [dbo].[UpdateStudentById]
    @StudentId INT,
    @Student UpdateStudentPayloadType READONLY
AS
BEGIN
    DECLARE @Null AS VARCHAR = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;
		    DECLARE @FacultyID UNIQUEIDENTIFIER;
			DECLARE @BranchID INT;
			SET @FacultyID = (SELECT TOP 1 FacultyID FROM [dbo].[Faculty] WHERE  UserName = (SELECT TOP 1 Faculty FROM @Student));
			SET @BranchID  = (SELECT TOP 1 DeptID FROM [dbo].[Department] WHERE  Name = (SELECT TOP 1 Branch FROM @Student));

			--Update Student data
			UPDATE Student
			SET
				FirstName = (SELECT TOP 1 FirstName FROM @Student),
				LastName  = (SELECT TOP 1 LastName FROM @Student),
				UserName  = (SELECT TOP 1 UserName FROM @Student),
				Email     = (SELECT TOP 1 Email FROM @Student)
			WHERE
				StudentID = @StudentId;

			-- DELETE StudentCourse data
			DELETE FROM StudentCourse WHERE StudentID = @StudentId;

			-- Update StudentCourse data
			INSERT INTO StudentCourse (StudentID, CourseID, BranchName,FacultyID)
			SELECT @StudentID, c.CourseID, d.Name, @FacultyID
			FROM Course c
			INNER JOIN Department d ON c.DeptID = d.DeptID
			INNER JOIN FacultyCourse fc on c.Name = fc.CourseName
			WHERE c.DeptID = @BranchID AND fc.FacultyID = @FacultyID;

			-- Delete StudentSubject data
			DELETE FROM StudentSubject WHERE StudentID = @StudentId;

            -- Update StudentSubject data
			INSERT INTO StudentSubject (SubjectName,StudentID, CourseID, FacultyID, BranchName)
			SELECT s.Name,@StudentID, c.CourseID, @FacultyID, d.Name
			FROM Subject s
			INNER JOIN Course c ON s.CourseID = c.CourseID
			INNER JOIN Department d ON c.DeptID = d.DeptID
			INNER JOIN FacultySubject fs ON s.Name = fs.SubjectName
			WHERE c.DeptID = @BranchID AND fs.FacultyID = @FacultyID;

			SET @Response = 'Success';

        COMMIT TRANSACTION;

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
