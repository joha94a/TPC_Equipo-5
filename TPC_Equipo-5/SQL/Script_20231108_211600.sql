USE DB_CLINICA_EQ5
GO

ALTER TABLE Usuario ALTER COLUMN MedicoID INT NULL;

INSERT INTO Usuario VALUES ('Admin', 'admin', 3,NULL,1);