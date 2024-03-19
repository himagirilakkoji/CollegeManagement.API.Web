USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertExamMarksDetails]    Script Date: 19-03-2024 12:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Description:
    This procedure will Insert ExamMarksDetails .

Affected tables:
    [dbo].[ExamMarks];

High-level flow:
     01.Insert Student data with courses,subjects into corresponding tables 
*/


ALTER PROCEDURE [dbo].[InsertExamMarksDetails]
    @InputAsJSON NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Null AS VARCHAR(10) = NULL;
    DECLARE @Response AS VARCHAR(MAX) = NULL;
	DECLARE @BranchName VARCHAR(50);

    BEGIN TRY
	       
	         SET @BranchName = JSON_VALUE(@InputAsJSON, '$.branch');
			 
			 --Check given Branch does not belongs to Student or not
			 IF NOT EXISTS (
			                SELECT DISTINCT 1 FROM StudentCourse sc
                              INNER JOIN Student s ON s.StudentID = sc.StudentID
                            WHERE s.UserName = JSON_VALUE(@InputAsJSON, '$.studentName') AND sc.BranchName = @branchName)
			 BEGIN
			       SET @Response = 'Branch does not belongs to Student ,Pleae check again';
			       SELECT @Null AS [ErrorProcedure], 
		           @Response AS [Response];
				   RETURN
			 END

			 --Check given data is duplicate or not
			 IF EXISTS (
			            SELECT 1 FROM [dbo].[ExamMarks] WHERE StudentID = (SELECT StudentID FROM [dbo].[Student] s 
			            WHERE s.UserName = JSON_VALUE(@InputAsJSON, '$.studentName'))
						    AND classRoom =  TRIM(JSON_VALUE(@InputAsJSON, '$.classRoom')) 
						    AND semester =  TRIM(JSON_VALUE(@InputAsJSON, '$.semester')))
			 BEGIN
					SET @Response = 'Already exists';
					SELECT @Null AS [ErrorProcedure], 
		            @Response AS [Response];
				    RETURN
			 END
			
			--check If student is already saved in class then it won't be allowed to another class
			IF EXISTS (
				SELECT 1 
				FROM [dbo].[ExamMarks] em
				INNER JOIN [dbo].[Student] s ON em.StudentID = s.StudentID
				WHERE s.UserName = JSON_VALUE(@InputAsJSON, '$.studentName')
				AND em.classRoom <> TRIM(JSON_VALUE(@InputAsJSON, '$.classRoom'))
			)
			 BEGIN
				SET @Response = 'Cannot save marks for a different class if already saved for a class in the semester';
				SELECT @Null AS [ErrorProcedure], 
		        @Response AS [Response];
				RETURN
			 END
			 ELSE
             BEGIN
			    BEGIN TRANSACTION;
					INSERT INTO [dbo].[ExamMarks](StudentID,CourseID,SubjectID,Marks,FacultyID,classRoom,semester)
					SELECT  st.StudentID,
					        ss.CourseID,
							sub.SubjectID,
							s.marks,
							ss.FacultyID,
							JSON_VALUE(@InputAsJSON, '$.classRoom') AS classRoom,	
							JSON_VALUE(@InputAsJSON, '$.semester') AS semester
					FROM
						OPENJSON(@InputAsJSON, '$.subjects') WITH (
							subjName NVARCHAR(255),
							marks INT
						) s
					INNER JOIN [dbo].[StudentSubject] ss ON s.subjName = ss.SubjectName 
					INNER JOIN Student st ON st.StudentID = ss.StudentID
					Inner join subject sub on sub.Name = ss.SubjectName 
					WHERE ss.StudentID = (select s.StudentID from Student s where s.UserName = JSON_VALUE(@InputAsJSON, '$.studentName'));
				    
					SET @Response = 'Success';

				    SELECT @Null AS [ErrorProcedure], 
		           @Response AS [Response];

               COMMIT TRANSACTION;
		     END

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT
		ERROR_MESSAGE() AS [ErrorProcedure], 
		@Response AS [Response];
    END CATCH
END;
