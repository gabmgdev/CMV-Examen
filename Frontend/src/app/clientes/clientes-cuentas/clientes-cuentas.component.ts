import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteCuentaDto, ClienteDto } from '../ClienteDto';
import { ClientesService } from '../clientes.service';

@Component({
  selector: 'app-clientes-cuentas',
  templateUrl: './clientes-cuentas.component.html',
  styleUrls: ['./clientes-cuentas.component.css']
})
export class ClientesCuentasComponent implements OnInit {
  cliente: ClienteDto;
  cuentas: ClienteCuentaDto[];
  columnasAMostrar = ['idCuenta', 'cliente', 'nombreCuenta', 'saldoActual', 'fechaContratacion', 'fechaUltimoMov'];

  constructor(private clientesService: ClientesService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.clientesService.obtenerPorId(params.id)
        .subscribe(cliente => {
          this.cliente = cliente;
          this.clientesService.obtenerCuentasDeCliente(params.id)
            .subscribe(cuentas => {
              this.cuentas = cuentas;
              console.log(cuentas);
            }, () => { this.router.navigate(['/']) })
        }, () => this.router.navigate(['/']))
    });
  }

}
