USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetDepartmentData]    Script Date: 04-03-2024 16:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will get the all Departmentdata .

Called from:
	[dbo].[Department]
	[dbo].[Course]
	[dbo].[Subject]

High-level flow:
     01.Get the Department with Courses and Subjects with help of joining these 3 tables [dbo].[Department],[dbo].[Course],[dbo].[Subject]
*/


CREATE PROCEDURE [dbo].[GetDepartmentdata]
AS
BEGIN
    DECLARE @Null AS VARCHAR = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL; -- Get Response
 
    BEGIN TRY
        -- Get Departmentdata
        SET @Response = (
            SELECT
                d.DeptID AS departmentId,
                d.[Name] AS departmentName,
                (
                    SELECT
                        c.[CourseID] AS courseId,
                        c.[Name] AS courseName,
                        (
                            SELECT
                                s.[SubjectID] AS subjectId,
                                s.[Name] AS subjectName
                            FROM
                                [dbo].[Subject] s
                            WHERE
                                s.[CourseID] = c.[CourseID]
                            FOR JSON PATH
                        ) AS subjects
                    FROM
                        [dbo].[Course] c
                    WHERE
                        c.DeptID = d.DeptID
                    FOR JSON PATH
                ) AS courses
            FROM
                [dbo].[Department] d
            FOR JSON PATH
        );
 
        SELECT
            @Null AS [ErrorProcedure],
            @Response AS [Response];
 
    END TRY
    BEGIN CATCH
        SELECT
            @Null AS [ResponseCode],
            ERROR_MESSAGE() AS [ErrorProcedure],
            @Response AS [Response];
    END CATCH
END;