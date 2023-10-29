CREATE DATABASE DB_CLINICA_EQ5;
GO

USE DB_CLINICA_EQ5;
GO

CREATE TABLE Paciente (
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL,
	Fecha_Nacimiento DATE NOT NULL,
	Genero CHAR NOT NULL,
	Direccion VARCHAR(500),
	Telefono VARCHAR(20),
	Mail VARCHAR(250) NOT NULL,
	Observaciones VARCHAR(MAX)
);
