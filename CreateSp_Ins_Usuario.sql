USE [Prueba]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarPersonas]    Script Date: 04/01/2025 13:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Ins_Usuarios]
@Id int=0,
@Usuario varchar(50),
@Pass varchar(256)
AS
BEGIN

	IF(@Id=0 OR @ID IS NULL)
	BEGIN
		INSERT Usuarios(Usuario,Pass,FechaCreacion)
		VALUES(@Usuario,@Pass,GETDATE())
	END
	ELSE
	BEGIN
		IF EXISTS (SELECT 1 FROM Usuarios WHERE Identificador = @ID)
			BEGIN
				UPDATE Usuarios
				SET Usuario=@Usuario,
					Pass=@Pass
				where Identificador=@Id
			END
		ELSE
			BEGIN
				INSERT Usuarios(Usuario,Pass,FechaCreacion)
				VALUES(@Usuario,@Pass,GETDATE())
			END
	END



END