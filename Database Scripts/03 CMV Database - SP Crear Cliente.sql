-- -------------------------------------
-- Stored Procedure: CREAR_CLIENTE
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE CREAR_CLIENTE (
	@nombre NVARCHAR(30),
	@apellidoPaterno NVARCHAR(30),
	@apellidoMaterno NVARCHAR(30) = NULL,
	@rfc VARCHAR(13),
	@curp VARCHAR(18)
)
AS
BEGIN
	INSERT INTO TBL_CMV_CLIENTE (
		nombre,
		apellidoPaterno,
		apellidoMaterno,
		rfc,
		curp,
		fechaAlta
	) VALUES (
		@nombre,
		@apellidoPaterno,
		@apellidoMaterno,
		@rfc,
		@curp,
		GETDATE()
	)
END