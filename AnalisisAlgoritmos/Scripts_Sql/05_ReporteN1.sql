USE [estaDiseno]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertRegistro]    Script Date: 06/09/2015 6:44:12 p. m. ******/
DROP PROCEDURE [dbo].[sp_estadisticaXrango]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertRegistro]    Script Date: 06/09/2015 6:44:12 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_estadisticaXrango]
	@id_algoritmo			int,
	@id_rango				int
AS
begin
	if @id_algoritmo <> 7
	begin
		select distinct
			   a.nom_algoritmo,
			   e.tiempo_real_cpu,
			   e.tiempo_cpu,
			   e.tiempo_e_s,
			   e.porcentaje_cpu_wall
			 from 
				dbo.algoritmo a
					inner join dbo.estadisticXalgoritmo e
						on a.id_algoritmo = e.id_algoritmo
					inner join dbo.rango r
						on e.id_rango = r.id_rango
			where a.id_algoritmo = @id_algoritmo
				  and  r.id_rango = @id_rango;
	end
	if @id_algoritmo = 7 
	begin
		select distinct
			   a.nom_algoritmo,
			   e.tiempo_real_cpu,
			   e.tiempo_cpu,
			   e.tiempo_e_s,
			   e.porcentaje_cpu_wall
			 from 
				dbo.algoritmo a
					inner join dbo.estadisticXalgoritmo e
						on a.id_algoritmo = e.id_algoritmo
					inner join dbo.rango r
						on e.id_rango = r.id_rango
			where  r.id_rango = @id_rango;
	end
end
GO