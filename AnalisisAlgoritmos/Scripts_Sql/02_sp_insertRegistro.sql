USE [estaDiseno]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertRegistro]    Script Date: 06/09/2015 10:14:12 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_insertRegistro]
	@id_algoritmo	 int,
	@id_rango		 int,
	@tiempo_cpu      numeric(7,2),
	@tiempo_total_eje  numeric(7,2),
	@tiempo_e_s        numeric(7,2),
	@porcentaje_cpu_wall  numeric(7,2)
AS
begin
	insert into dbo.estadisticXalgoritmo
		(
			id_algoritmo,
			id_rango,
			tiempo_cpu,
			tiempo_total_eje,
			tiempo_e_s,
			porcentaje_cpu_wall
		) values
		(@id_algoritmo,@id_rango,@tiempo_cpu,@tiempo_total_eje,@tiempo_e_s,@porcentaje_cpu_wall);
end