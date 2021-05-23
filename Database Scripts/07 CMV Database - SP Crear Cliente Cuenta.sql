-- -------------------------------------
-- Stored Procedure: CREAR_CLIENTE_CUENTA
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE CREAR_CLIENTE_CUENTA (
	@idCliente INT,
	@idCuenta INT,
	@saldoActual MONEY = 0,
	@fechaContratacion DATETIME = NULL,
	@fechaUltimoMovimiento DATETIME = NULL
)
AS	
BEGIN
	IF (@fechaContratacion IS NOT NULL AND @fechaUltimoMovimiento IS NOT NULL AND (@fechaContratacion > @fechaUltimoMovimiento))
		OR (@fechaContratacion IS NOT NULL AND @fechaUltimoMovimiento IS NULL AND (@fechaContratacion > GETDATE()))
		OR (@fechaContratacion IS NULL AND @fechaUltimoMovimiento IS NOT NULL AND (GETDATE() > @fechaUltimoMovimiento))
	BEGIN
		RAISERROR ('Fecha de contratacion debe ser anterior o igual a fecha de ultimo movimiento',1,1);
	END
	ELSE
	BEGIN
		INSERT INTO TBL_CMV_CLIENTE_CUENTA (
			idCliente,
			idCuenta,
			saldoActual,
			fechaContratacion,
			fechaUltimoMovimiento
		) VALUES (
			@idCliente,
			@idCuenta,
			@saldoActual,
			ISNULL(@fechaContratacion, GETDATE()),
			ISNULL(@fechaUltimoMovimiento, GETDATE())
		);
	END
END