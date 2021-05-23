-- -------------------------------------
-- Stored Procedure: LISTAR_CLIENTES_PAGINACION
-- -------------------------------------
USE CMV
GO

CREATE PROCEDURE LISTAR_CLIENTES_PAGINACION (
	@inicio INT,
	@recordsPorPagina INT,
	@totalRecords INT OUTPUT
)
AS
BEGIN
	IF @inicio < 0 OR @recordsPorPagina <= 0
	BEGIN
		RAISERROR ('Datos de paginacion invalidos', 1, 1);
	END
	SET NOCOUNT ON;
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
	ORDER BY idCliente
	OFFSET @inicio ROWS
	FETCH NEXT @recordsPorPagina ROWS ONLY;

	SELECT @totalRecords = COUNT(*) FROM TBL_CMV_CLIENTE;
END;