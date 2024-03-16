USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllFacultiesByPagination]    Script Date: 16-03-2024 15:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will retrive faculties.

Called from:
	[dbo].[Faculty]
	[dbo].[FacultyCourse]
	[dbo].[FacultySubject]

High-level flow:
     01.Get all faculties with help of joining these 3 tables Faculty, FacultyCourse,FacultySubject
*/

--exec [dbo].[GetAllFacultiesByPagination] 1,2
CREATE PROCEDURE [dbo].[GetAllFacultiesByPagination]
    @PageNumber INT = 1,
    @PageSize INT = 2
AS
BEGIN
    DECLARE @Null AS VARCHAR = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL; -- Get Response
 
    BEGIN TRY
        -- Get Departmentdata
        SET @Response = (
		                SELECT
						f.FacultyID,
						f.FirstName,
						f.lastName,
						f.UserName,
						f.Email,
						f.Dept,
                           (
							SELECT
							c.CourseID,
							c.CourseName,
							(
								SELECT
									s.SubjectID,
									s.SubjectName
								FROM
									[dbo].[FacultySubject] s WITH (NOLOCK)
								WHERE
									s.CourseName = c.CourseName
									AND s.FacultyID = f.FacultyID -- Correlate with FacultyID
								FOR JSON PATH
							)   AS subjects
							FROM
										[dbo].[FacultyCourse] c WITH (NOLOCK)
							WHERE
										c.FacultyID = f.FacultyID -- Correlate with FacultyID
							FOR JSON PATH
								) AS courses
							FROM
								[dbo].[Faculty] f WITH (NOLOCK)
							ORDER BY
                                f.FacultyID
							OFFSET (@PageNumber - 1) * @PageSize ROWS -- Calculate offset based on page number and page size
                            FETCH NEXT @PageSize ROWS ONLY -- Fetch only the specified number of rows
							FOR JSON PATH
						   );
 
        SELECT
            @Null AS [ErrorProcedure],
            @Response AS [Response];
 
    END TRY
    BEGIN CATCH
        SELECT
            ERROR_MESSAGE() AS [ErrorProcedure],
            @Response AS [Response];
    END CATCH
END;