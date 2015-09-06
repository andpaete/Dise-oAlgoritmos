SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_rango]
	
AS
begin
	select id_rango,valorFinal from dbo.rango
end