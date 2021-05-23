-- -------------------------------------
-- Stored Procedure: LISTAR_CLIENTES
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE LISTAR_CLIENTES
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
END;