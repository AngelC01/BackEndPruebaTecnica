CREATE DATABASE Prueba
GO

USE Prueba
GO


CREATE TABLE Personas (
    Identificador INT IDENTITY(1,1) PRIMARY KEY,    
    Nombres NVARCHAR(100) NOT NULL,                   
    Apellidos NVARCHAR(100) NOT NULL,                 
    NumeroIdentificacion NVARCHAR(50) NOT NULL,       
    Email NVARCHAR(100) NOT NULL,                     
    TipoIdentificacion NVARCHAR(50) NOT NULL,     
    FechaCreacion DATETIME DEFAULT GETDATE(),         
    IdentificacionCompleta AS                        
        (TipoIdentificacion + '-' + NumeroIdentificacion) PERSISTED,
    NombreCompleto AS                                 
        (Nombres + ' ' + Apellidos) PERSISTED
);

CREATE TABLE Usuarios (
    Identificador INT IDENTITY(1,1) PRIMARY KEY,  
    Usuario NVARCHAR(50) NOT NULL UNIQUE,         -- Nombre de usuario (debe ser único)
    Pass NVARCHAR(256) NOT NULL,                 
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Usuarios (Usuario, Pass,FechaCreacion)
VALUES ('admin', 'Pa$$w0rd2027_546',GETDATE());