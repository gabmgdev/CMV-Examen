-- -------------------------------------
-- Stored Procedure: EDITAR_CLIENTE
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE EDITAR_CLIENTE (
	@idCliente INT,
	@nombre NVARCHAR(30) = NULL,
	@apellidoPaterno NVARCHAR(30) = NULL,
	@apellidoMaterno NVARCHAR(30) = NULL,
	@rfc VARCHAR(13) = NULL,
	@curp VARCHAR(18) = NULL,
	@fechaAlta DATETIME = NULL
)
AS
BEGIN
	IF EXISTS (SELECT * FROM TBL_CMV_CLIENTE WHERE idCliente = @idCliente)
	BEGIN
		UPDATE TBL_CMV_CLIENTE 
		SET
			nombre = ISNULL(@nombre, nombre),
			apellidoPaterno= ISNULL(@apellidoPaterno, apellidoPaterno),
			apellidoMaterno = ISNULL(@apellidoMaterno, apellidoMaterno),
			rfc = ISNULL(@rfc, rfc),
			curp = ISNULL(@curp, curp),
			fechaAlta = ISNULL(@fechaAlta, fechaAlta)
		WHERE idCliente = @idCliente;
	END
	ELSE
	BEGIN
		RAISERROR ( 'Cliente no encontrado',1,1)
	END
END