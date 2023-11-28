    
ALTER PROC CalendarioTurnosDisponiblesGet    
@especialidadId INT    
AS    
    
set LANGUAGE Spanish    
--DOMINGO ES 7    
--DECLARE @especialidadId INT = 3    
    
DECLARE @intervaloMesMaximo INT = 1    
DECLARE @hoy DATE = getdate()--convert(varchar, getdate(), 103)    
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
WHERE me.IDEspecialidad = 3
ORDER BY h.ID
    
DECLARE @horariosCantidad INT = (SELECT TOP 1 Id FROM #horarioDisponible ORDER BY Id DESC)    
CREATE TABLE #horasDiscriminadas (    
 Dia INT,    
 Desde TIME,    
 Hasta TIME,    
 MedicoId INT    
);    
    
DECLARE @indexIdHorarios INT = (SELECT TOP 1 Id FROM #horarioDisponible)    
WHILE(@indexIdHorarios <= @horariosCantidad)    
BEGIN    
 DECLARE @horaIndex TIME = (SELECT TOP 1 Hora_Inicio FROM #horarioDisponible WHERE Id = @indexIdHorarios)    
 DECLARE @horaFin TIME = (SELECT TOP 1 Hora_Fin FROM #horarioDisponible WHERE Id = @indexIdHorarios)    
 DECLARE @dia INT = (SELECT TOP 1 Dia FROM #horarioDisponible WHERE Id = @indexIdHorarios)    
 WHILE (@horaIndex < @horaFin)    
 BEGIN    
  INSERT INTO #horasDiscriminadas VALUES (@dia, @horaIndex, DATEADD(HOUR, 1, @horaindex), (SELECT TOP 1 MedicoId FROM #horarioDisponible WHERE Id = @indexIdHorarios))    
  SET @horaIndex = DATEADD(HOUR,1,@horaIndex)    
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
 INNER JOIN #horasDiscriminadas h ON h.Dia = DATEPART(weekDay, d.Fecha)    
 INNER JOIN Medico m ON m.Id = h.MedicoId    
WHERE DATEADD(MINUTE, (DATEPART(HOUR, h.Desde)*60 + DATEPART(MINUTE, h.Desde)),cast(d.Fecha as dateTIME)) > GETDATE() AND (DATEADD(MINUTE, (DATEPART(HOUR, h.Desde)*60 + DATEPART(MINUTE, h.Desde)),cast(d.Fecha as dateTIME))) NOT IN (SELECT Fecha FROM Turno
  
 WHERE MedicoId = h.MedicoId AND Fecha > GETDATE() AND Estado = 1)    
ORDER BY d.Fecha, h.MedicoId, h.Desde    
    
DROP TABLE #horarioDisponible    
DROP TABLE #dias    
DROP TABLE #horasDiscriminadas