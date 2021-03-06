USE [estaDiseno]
GO

set ansi_padding on
go

if object_id('[dbo].[sp_insertRegistro]','P') is not null drop procedure [dbo].[sp_insertRegistro]
go

create PROCEDURE [dbo].[sp_insertRegistro]
(
	@id_algoritmo			int,
	@id_rango				int,
	@tiempo_cpu_real		numeric(12,2),
	@tiempo_cpu				numeric(12,2),
	@tiempo_e_s				numeric(12,0),
	@porcentaje_cpu_wall	numeric(12,2)
)

as

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

end -- Fin begin

set ansi_padding off
go
