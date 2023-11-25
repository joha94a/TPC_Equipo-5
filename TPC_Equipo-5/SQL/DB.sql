CREATE DATABASE DB_CLINICA_EQ5;
GO

USE DB_CLINICA_EQ5;
GO

CREATE TABLE Paciente (
	ID INT IDENTITY(1,1),
	DNI INT UNIQUE NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL,	
	Fecha_Nacimiento DATE NOT NULL,
	Genero CHAR NOT NULL,
	Direccion VARCHAR(500),
	Telefono VARCHAR(20),
	Mail VARCHAR(250) NOT NULL,
	Observaciones VARCHAR(MAX),
    PRIMARY KEY (ID)
);

CREATE TABLE Especialidad (
	ID INT IDENTITY(1,1),
	Codigo VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(100),
    PRIMARY KEY (ID)
);


CREATE TABLE Horario (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Dia INT NOT NULL,
	Hora_Inicio TIME NOT NULL,
	Hora_Fin TIME NOT NULL,
);


CREATE TABLE Medico (
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	Mail VARCHAR(100) NOT NULL,
    PRIMARY KEY (ID)
);


CREATE TABLE PerfilAcceso (
	ID INT IDENTITY(1,1),
	Codigo VARCHAR(10) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	Nivel_Acceso INT NOT NULL,
    PRIMARY KEY (ID)
);

INSERT INTO PerfilAcceso VALUES
('MED', 'Medico', 1 ),
('REC', 'Recepcionista',  2 ),
('ADM', 'Administrador', 3 )

CREATE TABLE Turno (
	ID INT IDENTITY(1,1),
	Fecha DATETIME NOT NULL,
	Hora DATETIME NOT NULL,
	MedicoID INT NOT NULL,
	PacienteID INT NOT NULL,
	Observaciones VARCHAR(MAX) NOT NULL,
	Estado INT NOT NULL,
    PRIMARY KEY (ID)
);


CREATE TABLE Usuario (
	ID INT IDENTITY(1,1),
	Nombre_Usuario VARCHAR(50) NOT NULL,
	Contrasena VARCHAR(50) NOT NULL,
	PerfilAccesoID INT NOT NULL,
	MedicoID INT NOT NULL,
    PRIMARY KEY (ID)
);

create table Medico_Especialidad(
	ID INT IDENTITY(1,1) primary key not null,
	IDEspecialidad int not null foreign key references Especialidad(ID),
	IDMedico int not null foreign key references Medico(ID)
);

create table Medico_Horario(
	ID INT IDENTITY(1,1) not null,
	IDHorario int not null foreign key references Horario(ID),
	IDMedico int not null foreign key references Medico(ID)
);