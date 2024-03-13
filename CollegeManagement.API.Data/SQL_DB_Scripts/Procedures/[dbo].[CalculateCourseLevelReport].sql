USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[CalculateCourseLevelReport]    Script Date: 13-03-2024 20:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will get the all CourseLevelReport .

Called from:
	[dbo].[ExamMarks]
	[dbo].[Course]

High-level flow:
     01.Get the CourseLevelReport with ExamMarks, Courses with help of joining these 2 tables [dbo].[ExamMarks],[dbo].[Course]
*/

--exec [dbo].[CalculateCourseLevelReport] 'B0C311E2-9638-48FF-8F0A-CDDD1CBD9F00'
ALTER PROCEDURE [dbo].[CalculateCourseLevelReport]
     @FacultyID UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        -- Get CourseLevelReport
		SELECT
			em.CourseID,
			c.Name,
			CAST(ROUND(AVG(Marks), 2) AS DECIMAL(10, 2)) AS AverageMarks
		FROM
			[dbo].[ExamMarks] em
			INNER JOIN [dbo].[Course] c ON em.CourseID = c.CourseID
		WHERE
			FacultyID =   @FacultyID
		GROUP BY
			em.CourseID,
			c.Name;
    END TRY

    BEGIN CATCH
        SELECT
            ERROR_MESSAGE() AS [ErrorProcedure];
    END CATCH
END;