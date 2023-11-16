
ALTER TABLE Turno
DROP COLUMN Hora;
ALTER TABLE Turno
DROP COLUMN Numero;

CREATE PROC TurnosBuscadorGet
@fechaDesde DATETIME = NULL,
@fechaHasta DATETIME = NULL,
@estado INT = NULL
AS

--DECLARE @fechaDesde DATETIME = NULL
--DECLARE @fechaHasta DATETIME = NULL
--DECLARE @estado INT = 0

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
  AND (@fechaDesde IS NULL OR t.Fecha >= @fechaDesde)
  AND (@fechaHasta IS NULL OR t.Fecha <= @fechaHasta)