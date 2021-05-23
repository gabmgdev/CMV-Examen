-- -------------------------------------
-- Stored Procedure: LISTAR_CLIENTE
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE LISTAR_CLIENTE (
	@idCliente INT
)
AS
BEGIN
	SELECT
		idCliente,
		nombre,
		apellidoPaterno,
		apellidoMaterno,
		rfc,
		curp,
		fechaAlta
	FROM
		TBL_CMV_CLIENTE
	WHERE idCliente = @idCliente;
END