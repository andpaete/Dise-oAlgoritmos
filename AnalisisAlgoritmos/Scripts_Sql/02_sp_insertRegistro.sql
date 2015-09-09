USE [estaDiseno]

GO
drop PROCEDURE [dbo].[sp_insertRegistro]
/****** Object:  StoredProcedure [dbo].[sp_insertRegistro]    Script Date: 06/09/2015 10:14:12 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_insertRegistro]
	@id_algoritmo			int,
	@id_rango				int,
	@tiempo_cpu_real		numeric(7,2),
	@tiempo_cpu				numeric(7,2),
	@tiempo_e_s				numeric(7,2),
	@porcentaje_cpu_wall	numeric(7,2)
AS
begin
	delete from dbo.estadisticXalgoritmo where id_algoritmo = @id_algoritmo and id_rango = @id_rango;
	insert into dbo.estadisticXalgoritmo
		(
			id_algoritmo,
			id_rango,
			tiempo_real_cpu,
			tiempo_cpu,
			tiempo_e_s,
			porcentaje_cpu_wall
		) values
		(@id_algoritmo,@id_rango,@tiempo_cpu_real,@tiempo_cpu,@tiempo_e_s,@porcentaje_cpu_wall);
end