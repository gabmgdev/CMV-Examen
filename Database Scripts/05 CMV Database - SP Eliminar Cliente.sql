-- -------------------------------------
-- Stored Procedure: ELIMINAR_CLIENTE
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE ELIMINAR_CLIENTE (
	@idCliente INT
)
AS
BEGIN
	IF EXISTS (SELECT * FROM TBL_CMV_CLIENTE WHERE idCliente = @idCliente)
	BEGIN
		DELETE FROM TBL_CMV_CLIENTE WHERE idCliente = @idCliente;
	END
	ELSE
	BEGIN
		RAISERROR ( 'Cliente no encontrado',1,1)
	END
END