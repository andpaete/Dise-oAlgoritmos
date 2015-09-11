USE [estaDiseno]
GO

if object_id('[dbo].[sp_estadisticaXrango]','P') is not null drop procedure [dbo].[sp_estadisticaXrango]
go

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