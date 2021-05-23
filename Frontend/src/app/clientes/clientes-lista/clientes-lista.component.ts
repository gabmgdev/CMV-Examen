import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ClienteDto } from '../ClienteDto';
import { ClientesService } from '../clientes.service';

@Component({
  selector: 'app-clientes-lista',
  templateUrl: './clientes-lista.component.html',
  styleUrls: ['./clientes-lista.component.css']
})
export class ClientesListaComponent implements OnInit {
  clientes: ClienteDto[] = [];
  cantidadTotalRegistros: number;
  pagina: number = 1;
  recordsPorPagina: number = 5;
  columnasAMostrar = ['id', 'nombre', 'rfc', 'curp', 'fechaAlta', 'acciones'];

  constructor(private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.cargarRegistros(this.pagina, this.recordsPorPagina);
  }

  cargarRegistros(pagina: number, recordsPorPagina: number) {
    this.clientesService.obtenerTodos(pagina, recordsPorPagina)
      .subscribe((respuesta: HttpResponse<ClienteDto[]>) => {
        this.clientes = respuesta.body['data'];
        this.cantidadTotalRegistros = +respuesta.body['totalRegistros'];
      }, error => console.error(error));
  }

  actualizarPaginacion(datos: PageEvent) {
    this.pagina = datos.pageIndex + 1;
    this.recordsPorPagina = datos.pageSize;
    this.cargarRegistros(this.pagina, this.recordsPorPagina);
  }

  borrar(id: number) {
    this.clientesService.eliminarCliente(id)
      .subscribe(() => {
        this.cargarRegistros(this.pagina, this.recordsPorPagina);
      }, error => console.error(error));
  }
}
