USE [DB_CLINICA_EQ5]
GO

/****** Object:  StoredProcedure [dbo].[HorariosGet]    Script Date: 08/11/2023 0:18:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[HorariosGet]
@desde TIME = NULL,
@hasta TIME = NULL,
@dia INT = 0
AS

--DECLARE @desde TIME = '7:00'
--DECLARE @hasta TIME = '23:00'
--DECLARE @dia INT = NULL

SELECT 
	h.ID,
	h.Hora_Inicio,
	h.Hora_Fin,
	h.Dia 
FROM Horario h
WHERE (@dia = 0 OR h.Dia = @dia) AND(
    (@desde IS NULL AND @hasta IS NULL)
 OR (@desde IS NULL AND h.Hora_Inicio <= @hasta)
 OR (@hasta IS NULL AND h.Hora_Fin >= @desde)
 OR (@desde <= h.Hora_Inicio AND @hasta >= h.Hora_Inicio)
 OR (@desde <= h.Hora_Fin AND @hasta >= h.Hora_Fin)
 OR (@desde >= h.Hora_Inicio AND @hasta <= h.Hora_Fin)
)
GO


