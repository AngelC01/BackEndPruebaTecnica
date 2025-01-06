USE [Prueba]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarPersonas]    Script Date: 04/01/2025 13:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Login]
@Usuario varchar(50),
@Pass varchar(256)
AS
BEGIN
    SELECT 
	Identificador,
	Usuario,
	Pass ,
	FechaCreacion

    FROM Usuarios
	where Usuario=@Usuario and Pass=@Pass
END