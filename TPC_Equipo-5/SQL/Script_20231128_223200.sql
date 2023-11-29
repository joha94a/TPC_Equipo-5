USE [DB_CLINICA_EQ5]
GO

ALTER PROC [dbo].[TurnosBuscadorGet]  
@fechaDesde DATETIME = NULL,  
@fechaHasta DATETIME = NULL,  
@estado INT = NULL,
@idMedico INT = NULL
AS  
  
--DECLARE @fechaDesde DATETIME = NULL  
--DECLARE @fechaHasta DATETIME = NULL  
--DECLARE @estado INT = 0  
 
IF (@idMedico IS NOT NULL)
BEGIN
	SELECT   
		t.ID,  
		t.Fecha,  
		m.Apellido + ', ' + m.Nombre Medico,  
		p.Apellido + ', ' + p.Nombre Paciente,  
		t.Estado,  
		CASE  
			WHEN t.Estado = 1 THEN 'Activo'  
			WHEN t.Estado = 2 THEN 'Cancelado'  
			WHEN t.Estado = 3 THEN 'Completado'  
			WHEN t.Estado = 4 THEN 'Ausente'  
			ELSE ''  
		END EstadoStr  
	FROM Turno t  
		INNER JOIN Medico m ON m.Id = t.MedicoID  
		INNER JOIN Paciente p ON p.Id = t.PacienteID  
	WHERE m.ID = @idMedico
	  AND (@estado = 0 OR @estado = t.Estado)  
	  AND (@fechaDesde IS NULL OR CAST(t.Fecha AS DATE) >= @fechaDesde)  
	  AND (@fechaHasta IS NULL OR CAST(t.Fecha AS DATE) <= @fechaHasta)
	ORDER BY t.Fecha DESC
END
ELSE
BEGIN
	SELECT   
		t.ID,  
		t.Fecha,  
		m.Apellido + ', ' + m.Nombre Medico,  
		p.Apellido + ', ' + p.Nombre Paciente,  
		t.Estado,  
		CASE  
			WHEN t.Estado = 1 THEN 'Activo'  
			WHEN t.Estado = 2 THEN 'Cancelado'  
			WHEN t.Estado = 3 THEN 'Completado'  
			WHEN t.Estado = 4 THEN 'Ausente'  
			ELSE ''  
		END EstadoStr  
	FROM Turno t  
		INNER JOIN Medico m ON m.Id = t.MedicoID  
		INNER JOIN Paciente p ON p.Id = t.PacienteID  
	WHERE (@estado = 0 OR @estado = t.Estado)  
	  AND (@fechaDesde IS NULL OR CAST(t.Fecha AS DATE) >= @fechaDesde)  
	  AND (@fechaHasta IS NULL OR CAST(t.Fecha AS DATE) <= @fechaHasta)
	ORDER BY t.Fecha DESC
END
