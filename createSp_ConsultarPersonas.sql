CREATE PROCEDURE ConsultarPersonas
AS
BEGIN
    SELECT 
        Identificador,
        Nombres,
        Apellidos,
        NumeroIdentificacion,
        Email,
        TipoIdentificacion,
        FechaCreacion,
        IdentificacionCompleta,
        NombreCompleto
    FROM Personas
    ORDER BY FechaCreacion DESC;  
END;