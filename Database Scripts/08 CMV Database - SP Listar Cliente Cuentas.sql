-- -------------------------------------
-- Stored Procedure: LISTAR_CLIENTE_CUENTAS
-- -------------------------------------
USE CMV;
GO

CREATE PROCEDURE LISTAR_CLIENTE_CUENTAS (
	@idCliente INT
)
AS
BEGIN
	SELECT
		cuenta.idClienteCuenta,
		CONCAT(cliente.nombre, ' ', cliente.apellidoPaterno, ' ', cliente.apellidoMaterno) AS nombre_cliente,
		tipo_cuenta.nombreCuenta,
		cuenta.saldoActual,
		cuenta.fechaContratacion,
		cuenta.fechaUltimoMovimiento
	FROM
		TBL_CMV_CLIENTE cliente
	INNER JOIN (
		TBL_CMV_CLIENTE_CUENTA cuenta
		INNER JOIN CAT_CMV_TIPO_CUENTA tipo_cuenta
		ON cuenta.idCuenta = tipo_cuenta.idCuenta
	) ON cliente.idCliente = cuenta.idCliente
	WHERE
		cliente.idCliente = @idCliente;
END