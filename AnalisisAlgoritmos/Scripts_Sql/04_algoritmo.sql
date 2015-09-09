USE [estaDiseno]
GO

/****** Object:  StoredProcedure [dbo].[sp_rango]    Script Date: 06/09/2015 6:47:06 p. m. ******/


/****** Object:  StoredProcedure [dbo].[sp_rango]    Script Date: 06/09/2015 6:47:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_algoritmo]
	
AS
begin
	select id_algoritmo,nom_algoritmo from dbo.algoritmo
end
GO

