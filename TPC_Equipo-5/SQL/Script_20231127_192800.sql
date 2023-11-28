USE DB_CLINICA_EQ5
GO

ALTER TABLE Horario
ADD IDMedico INT FOREIGN KEY REFERENCES Medico(ID);

-- ANTES DE EJECUTAR LA SIGUIENTE CONSULTA HAY QUE ASEGURARSE DE SETEAR UN MEDICO A LOS HORARIOS EXISTENTES
-- update Horario set IDMedico = 1
ALTER TABLE Horario
ALTER COLUMN IDMEDICO INT NOT NULL;

DROP TABLE Medico_Horario;