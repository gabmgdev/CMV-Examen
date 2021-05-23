-- -------------------------------------
--	Script para crear la Base de Datos
-- 	y las tablas que la componen
-- -------------------------------------
CREATE DATABASE CMV;
GO

USE CMV
GO

-- Create Tables
CREATE TABLE [dbo].TBL_CMV_CLIENTE (
	idCliente INT IDENTITY (1, 1) PRIMARY KEY,
	nombre NVARCHAR(30) NOT NULL,
	apellidoPaterno NVARCHAR(30) NOT NULL,
	apellidoMaterno NVARCHAR(30),
	rfc VARCHAR(13) UNIQUE NOT NULL,
	curp VARCHAR(18) UNIQUE NOT NULL,
	fechaAlta DATETIME NOT NUll 
);

CREATE TABLE [dbo].CAT_CMV_TIPO_CUENTA (
	idCuenta INT IDENTITY (1, 1) PRIMARY KEY,
	nombreCuenta VARCHAR(50)
);

CREATE TABLE [dbo].TBL_CMV_CLIENTE_CUENTA (
	idClienteCuenta INT IDENTITY (1, 1) PRIMARY KEY,
	idCliente INT NOT NULL,
	idCuenta INT NOT NULL,
	saldoActual MONEY NOT NULL,
	fechaContratacion DATETIME NOT NULL,
	fechaUltimoMovimiento DATETIME NOT NULL,
	FOREIGN KEY (idCliente) REFERENCES TBL_CMV_CLIENTE (idCliente) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idCuenta) REFERENCES CAT_CMV_TIPO_CUENTA (idCuenta),
	UNIQUE (idCliente, idCuenta)
);