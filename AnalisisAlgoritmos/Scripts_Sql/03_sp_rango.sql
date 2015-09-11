USE [estaDiseno]
GO

if object_id('[dbo].[sp_rango]','P') is not null drop procedure [dbo].[sp_rango]
go

create PROCEDURE [dbo].[sp_rango]
	
AS
begin
	select id_rango,valorFinal from dbo.rango
end