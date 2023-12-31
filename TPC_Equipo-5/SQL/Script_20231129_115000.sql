USE [DB_CLINICA_EQ5]
GO
/****** Object:  StoredProcedure [dbo].[CalendarioTurnosDisponiblesGet]    Script Date: 29/11/2023 11:41:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
ALTER PROC [dbo].[CalendarioTurnosDisponiblesGet]    
@especialidadId INT    
AS    

SET LANGUAGE Spanish
SET DATEFIRST 1;  
--DOMINGO ES 7    
--DECLARE @especialidadId INT = 3  

DECLARE @intervaloMesMaximo INT = 1
DECLARE @hoy DATE = getdate()
DECLARE @fechaMaxima DATE = DATEADD(MONTH, @intervaloMesMaximo, GETDATE())
DECLARE @fechaIndex DATE = @hoy

SELECT @hoy Fecha INTO #dias

WHILE (@fechaIndex < @fechaMaxima)
BEGIN
	SET @fechaIndex = DATEADD(DAY, 1, @fechaIndex)
	INSERT INTO #dias VALUES (@fechaIndex)
END

SELECT ROW_NUMBER() OVER (ORDER BY h.ID) AS Id, h.Hora_Inicio, h.Hora_Fin, h.Dia, m.Id MedicoId INTO #horarioDisponible
FROM Horario h
INNER JOIN Medico m ON m.Id = h.IDMedico
INNER JOIN Medico_Especialidad me ON me.IDMedico = m.ID
WHERE me.IDEspecialidad = @especialidadId
ORDER BY h.ID

DECLARE @horariosCantidad INT = (SELECT TOP 1 Id FROM #horarioDisponible ORDER BY Id DESC)

CREATE TABLE #horasDiscriminadas (
 Fecha DATE,
 Desde TIME,
 Hasta TIME,
 MedicoId INT
);



DECLARE @indexIdHorarios INT = (SELECT TOP 1 Id FROM #horarioDisponible ORDER BY Id)
WHILE(@indexIdHorarios <= @horariosCantidad)
BEGIN

	DECLARE @dia INT = (SELECT TOP 1 Dia FROM #horarioDisponible WHERE Id = @indexIdHorarios)
	DECLARE @horaFin TIME = (SELECT TOP 1 Hora_Fin FROM #horarioDisponible WHERE Id = @indexIdHorarios)
	DECLARE @medicoId INT = (SELECT TOP 1 MedicoId FROM #horarioDisponible WHERE Id = @indexIdHorarios)
	DECLARE @indexFechas DATE
	
	SET @indexFechas = @hoy
	
	WHILE @indexFechas <= @fechaMaxima
	BEGIN
		IF DATEPART(weekday,@indexFechas) = @dia
		BEGIN
			DECLARE @horaIndex TIME = (SELECT TOP 1 Hora_Inicio FROM #horarioDisponible WHERE Id = @indexIdHorarios)
			WHILE (DATEADD(HOUR,1,@horaIndex) <= @horaFin)
			BEGIN
				DECLARE @turnosReservados INT = ( SELECT COUNT(*) FROM Turno
													 WHERE Fecha = (DATEADD(MINUTE, (DATEPART(HOUR, @horaIndex)*60 + DATEPART(MINUTE, @horaIndex)),cast(@indexFechas as DATETIME)))
													 AND MedicoID = @medicoId
													 AND Estado = 1)
				IF @turnosReservados = 0
					INSERT INTO #horasDiscriminadas VALUES (@indexFechas, @horaIndex, DATEADD(HOUR, 1, @horaindex), @medicoId )
				SET @horaIndex = DATEADD(HOUR,1,@horaIndex)
			END
		END
		SET @indexFechas = DATEADD(DAY, 1, @indexFechas)
	END
	SET @indexIdHorarios = @indexIdHorarios +1
END


SELECT
	ROW_NUMBER() OVER(Order by d.Fecha) Id,
	h.MedicoId,
	DATEADD(MINUTE, (DATEPART(HOUR, h.Desde)*60 + DATEPART(MINUTE, h.Desde)),cast(d.Fecha as dateTIME)) FechaHora,
	d.Fecha,
	h.Desde HoraDesde,
	h.Hasta HoraHasta,
	m.Apellido + ', ' + m.Nombre MedicoStr
FROM #dias d
INNER JOIN #horasDiscriminadas h ON h.Fecha = d.Fecha
INNER JOIN Medico m ON m.Id = h.MedicoId
WHERE DATEADD(MINUTE, (DATEPART(HOUR, h.Desde)*60 + DATEPART(MINUTE, h.Desde)),cast(d.Fecha as dateTIME)) > GETDATE()
ORDER BY d.Fecha, h.MedicoId, h.Desde    
    
DROP TABLE #horarioDisponible    
DROP TABLE #dias    
DROP TABLE #horasDiscriminadas