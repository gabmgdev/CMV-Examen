-- -------------------------------------
-- Stored Procedure: CREAR_TIPO_CUENTA
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE CREAR_TIPO_CUENTA (
	@nombreCuenta VARCHAR(50)
)
AS
BEGIN
	INSERT INTO CAT_CMV_TIPO_CUENTA (
		nombreCuenta
	) VALUES (
		@nombreCuenta
	);
END