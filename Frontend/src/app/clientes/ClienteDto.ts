export interface ClienteDto {
    idCliente: number;
    nombre: string;
    apellidoPaterno: string;
    apellidoMaterno: string;
    rfc: string;
    curp: string;
    fechaAlta: string;
}

export interface ClienteCreacionDto {
    nombre: string;
    apellidoPaterno: string;
    apellidoMaterno: string;
    rfc: string;
    curp: string;
}

export interface ClienteCuentaDto {
    idClienteCuenta: number;
    nombreCliente: string;
    nombreCuenta: string;
    saldoActual: number;
    fechaContratacion: string;
    fechaUltimoMovimiento: string;
}