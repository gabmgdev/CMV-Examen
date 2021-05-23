-- -------------------------------------
-- Script con el conjunto de sentencias
-- necesarias para insertar datos de
-- prueba en la Base de Datos
-- -------------------------------------
USE CMV;
GO

-- Crear Tipos de Cuenta
EXEC CREAR_TIPO_CUENTA @nombreCuenta = 'Ahorro';
EXEC CREAR_TIPO_CUENTA @nombreCuenta = 'Préstamo';
EXEC CREAR_TIPO_CUENTA @nombreCuenta = 'Inversión';

-- Crear Clientes
EXEC CREAR_CLIENTE @nombre = 'Juan', @apellidoPaterno = 'Sánchez', @apellidoMaterno = 'Ramírez', @rfc = 'SARJ121315PC9', @curp = 'SARJ21315HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Manuel', @apellidoPaterno = 'Reyes', @apellidoMaterno = 'Cruz', @rfc = 'RECM0870502RS1', @curp = 'RECM0870502HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Martha', @apellidoPaterno = 'Torres', @apellidoMaterno = 'Díaz', @rfc = 'TODM921203LT3', @curp = 'TODM921203HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Ana María', @apellidoPaterno = 'Moreno', @apellidoMaterno = 'Castillo', @rfc = 'MOCA780601NK2', @curp = 'MOCA780601HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Ricardo', @apellidoPaterno = 'Pérez', @apellidoMaterno = 'Rivera', @rfc = 'PERR940318LM2', @curp = 'PERR940318HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Margarita', @apellidoPaterno = 'Aguilar', @apellidoMaterno = 'Flores', @rfc = 'AGFM851112OP3', @curp = 'AGFM851112HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Carlos Antonio', @apellidoPaterno = 'Robles', @apellidoMaterno = 'Gómez', @rfc = 'ROGC880510WE2', @curp = 'ROGC880510HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Ulises', @apellidoPaterno = 'Morales', @apellidoMaterno = 'Romero', @rfc = 'MORU921111AJ3', @curp = 'MORU921111HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Fernanda', @apellidoPaterno = 'Rivera', @apellidoMaterno = 'Gutiérrez', @rfc = 'RIGA901225MN8', @curp = 'RIGA901225HMNRTB00';
EXEC CREAR_CLIENTE @nombre = 'Eduardo Esteban', @apellidoPaterno = 'Rodriguez', @apellidoMaterno = 'Solís', @rfc = 'ROSE860714KH0', @curp = 'ROSE860714HMNRTB00';


-- Crear Cuentas para clientes
EXEC CREAR_CLIENTE_CUENTA @idCliente = 1, @idCuenta = 1, @saldoActual = 1500, @fechaContratacion = '2010-08-10', @fechaUltimoMovimiento = '2015-12-29';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 2, @idCuenta = 1, @saldoActual = 8700.50, @fechaContratacion = '2012-10-04', @fechaUltimoMovimiento = '2018-11-22';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 3, @idCuenta = 2, @saldoActual = 2400, @fechaContratacion = '2014-01-28', @fechaUltimoMovimiento = '2015-07-12';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 4, @idCuenta = 1, @saldoActual = 17890, @fechaContratacion = '2014-05-02', @fechaUltimoMovimiento = '2014-05-02';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 1, @idCuenta = 3, @saldoActual = 1500, @fechaContratacion = '2016-11-10', @fechaUltimoMovimiento = '2016-11-12';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 5, @idCuenta = 1, @saldoActual = 290821.35, @fechaContratacion = '2011-11-11', @fechaUltimoMovimiento = '2014-04-30';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 6, @idCuenta = 2, @saldoActual = 15500, @fechaContratacion = '2017-03-12', @fechaUltimoMovimiento = '2015-07-12';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 7, @idCuenta = 3, @saldoActual = 70456, @fechaContratacion = '2019-08-26', @fechaUltimoMovimiento = '2020-12-05';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 8, @idCuenta = 2, @saldoActual = 1890, @fechaContratacion = '2019-10-13', @fechaUltimoMovimiento = '2021-03-01';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 2, @idCuenta = 1, @saldoActual = 24070, @fechaContratacion = '2020-07-07', @fechaUltimoMovimiento = '2021-05-10';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 9, @idCuenta = 2, @saldoActual = 806030.50, @fechaContratacion = '2021-04-25', @fechaUltimoMovimiento = '2021-04-26';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 4, @idCuenta = 3, @saldoActual = 1000, @fechaContratacion = '2018-03-22', @fechaUltimoMovimiento = '2020-09-14';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 6, @idCuenta = 2, @saldoActual = 7600, @fechaContratacion = '2019-12-07', @fechaUltimoMovimiento = '2019-12-29';
EXEC CREAR_CLIENTE_CUENTA @idCliente = 7, @idCuenta = 3, @saldoActual = 32906, @fechaContratacion = '2020-11-15', @fechaUltimoMovimiento = '2021-02-18';
