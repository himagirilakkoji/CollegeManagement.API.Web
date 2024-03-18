USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentMarksById]    Script Date: 19-03-2024 01:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will get the all GetStudentMarksById .

Called from:
	[dbo].[ExamMarks]
	[dbo].[Subject]

High-level flow:
     01.Get the GetStudentMarks by Id with ExamMarks, Subject with help of joining these 2 tables [dbo].[ExamMarks],[dbo].[Subject]
*/

--exec [dbo].[GetStudentMarksById] 1034
ALTER PROCEDURE [dbo].[GetStudentMarksById]
     @StudentID INT
AS
BEGIN
    BEGIN TRY
        -- Get ExamMarksReport
		SELECT
				em.StudentID,
				em.SubjectID,
				em.FacultyID,
				s.Name,
				em.Marks,
				em.classRoom,
				em.semester
			FROM
				ExamMarks em
				INNER JOIN Subject s ON em.SubjectID = s.SubjectID
			WHERE
				em.StudentID = @StudentID
    END TRY

    BEGIN CATCH
    END CATCH
END;