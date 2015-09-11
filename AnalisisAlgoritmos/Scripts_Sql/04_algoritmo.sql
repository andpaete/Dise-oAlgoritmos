USE [estaDiseno]
GO

if object_id('[dbo].[sp_algoritmo]','P') is not null drop procedure [dbo].[sp_algoritmo]
go

create PROCEDURE [dbo].[sp_algoritmo]
	
AS
begin
	select id_algoritmo,nom_algoritmo from dbo.algoritmo
end
GO

