USE [College_DB]
GO
/****** Object:  StoredProcedure [dbo].[SearchStudent]    Script Date: 20-03-2024 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
Description:
	This procedure will get filtered Student names based on text .

Called from:
	[dbo].[Student]

High-level flow:
     01.AutoSearch Student name with help of [dbo].[Student]
*/


--exec [dbo].[SearchStudent] 'sy'
ALTER PROCEDURE [dbo].[SearchStudent]
     @SearchText NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
			BEGIN
				SET NOCOUNT ON; -- Disable the row count from being returned

				--Return matched Student records only
				SELECT UserName AS StudentName
				FROM [dbo].[Student]
				WHERE UserName LIKE @SearchText + '%';
			END

    END TRY
    BEGIN CATCH
    END CATCH
END
