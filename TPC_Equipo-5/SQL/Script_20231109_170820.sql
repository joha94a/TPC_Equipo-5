

--declare @dni varchar(250) = '123'
--declare @nombre varchar(250) = ''
--declare @apellido varchar(250) = ''
--declare @fechaDesde Datetime = ''
--declare @fechaHasta Datetime = ''

CREATE PROC PacientesGet
@dni varchar(50) = '',
@nombre varchar(50) = '',
@apellido varchar(50) = '',
@fechaDesde Datetime = NULL,
@fechaHasta Datetime = NULL
AS

SELECT Id, DNI, Nombre, Apellido, Fecha_Nacimiento, Genero, Direccion, Telefono, Mail, Observaciones 
FROM Paciente 
WHERE 
    (@dni = '' OR DNI LIKE '%' + @dni + '%')
AND (@nombre = '' OR Nombre LIKE '%' + @nombre + '%')
AND (@apellido = '' OR Apellido LIKE '%' + @apellido + '%')
AND (@fechaDesde IS NULL OR Fecha_Nacimiento >= @fechaDesde) AND
(@fechaHasta IS NULL OR Fecha_Nacimiento <= @fechaHasta)