USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 12-03-2024 01:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will retrive Students.

Called from:
	[dbo].[Student]
	[dbo].[StudentCourse]
	[dbo].[StudentSubject]

High-level flow:
     01.Get all faculties with help of joining these 3 tables Student, StudentCourse,StudentSubject
*/

--exec [dbo].[GetAllStudents]

ALTER PROCEDURE [dbo].[GetAllStudents]
AS
BEGIN
    BEGIN TRY
							-- Get Studentdata
   						    SELECT
								s.StudentID,
								s.FirstName,
								s.LastName,
								s.UserName,
								s.Email,
								s.Password,
								sc.FacultyID,
								sc.Courses AS studentCourseEntities
							FROM
								[dbo].[Student] s
								LEFT JOIN
									(
										SELECT
											c.StudentID,
											c.FacultyID,
												(
													SELECT
														c2.CourseID AS StudentCourseID,
														c3.Name AS CourseName,
														c2.BranchName,
														c2.FacultyID as FacultyID,
															(
																SELECT
																	s2.StudentID AS StudentSubjectID,
																	s2.SubjectName,
																	s2.FacultyID
																FROM
																	[dbo].[StudentSubject] s2
																WHERE
																	s2.CourseID = c2.CourseID
																	AND s2.StudentID = c.StudentID
																FOR JSON PATH
															) AS studentSubjectEntities
													FROM
														[dbo].[StudentCourse] c2 join Course c3 on c2.CourseID = c3.CourseID
													WHERE
														c2.StudentID = c.StudentID
													FOR JSON PATH
												) AS Courses
										FROM
											[dbo].[StudentCourse] c
										GROUP BY
											c.StudentID,
											c.FacultyID
									) sc ON sc.StudentID = s.StudentID;
 
    END TRY
    BEGIN CATCH
        SELECT
            ERROR_MESSAGE() AS [ErrorProcedure];
    END CATCH
END;