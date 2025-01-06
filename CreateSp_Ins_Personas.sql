CREATE PROCEDURE [dbo].[Ins_Personas]
    @Id INT = 0,
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @NumeroIdentificacion NVARCHAR(50),
    @Email NVARCHAR(100),
    @TipoIdentificacion NVARCHAR(50)
AS
BEGIN
    IF (@Id = 0 OR @Id IS NULL)
    BEGIN
        INSERT INTO Personas (Nombres, Apellidos, NumeroIdentificacion, Email, TipoIdentificacion, FechaCreacion)
        VALUES (@Nombres, @Apellidos, @NumeroIdentificacion, @Email, @TipoIdentificacion, GETDATE());
    END
    ELSE
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.Personas WHERE Identificador = @Id)
        BEGIN
            UPDATE dbo.Personas
            SET Nombres = @Nombres,
                Apellidos = @Apellidos,
                NumeroIdentificacion = @NumeroIdentificacion,
                Email = @Email,
                TipoIdentificacion = @TipoIdentificacion
            WHERE Identificador = @Id;
        END
        ELSE
        BEGIN
			 INSERT INTO Personas (Nombres, Apellidos, NumeroIdentificacion, Email, TipoIdentificacion, FechaCreacion)
			 VALUES (@Nombres, @Apellidos, @NumeroIdentificacion, @Email, @TipoIdentificacion, GETDATE());
        END
    END
END
GO