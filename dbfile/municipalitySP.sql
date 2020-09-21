
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE SP_Municipality 
	-- Add the parameters for the stored procedure here
	 
    @Municipality_name    VARCHAR(10),  
    @Date     VARCHAR(10),  
    @Result        DECIMAL(10, 2)
AS
BEGIN
	
	SET NOCOUNT ON;

      IF NOT EXISTS (SELECT * FROM Municipalitydetails 
                   WHERE municipalityName = @Municipality_name
                   AND Date = @Date)
        BEGIN  
            INSERT INTO Municipalitydetails  
                        (  
                         municipalityName,  
                         Date,  
                         Result)  
            VALUES     (  
                         @Municipality_name,  
                         @Date,  
                         @Result)  
        END 
		
	
END
GO


