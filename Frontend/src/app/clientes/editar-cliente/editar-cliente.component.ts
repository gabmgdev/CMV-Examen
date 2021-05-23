import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteCreacionDto, ClienteDto } from '../ClienteDto';
import { ClientesService } from '../clientes.service';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.css']
})
export class EditarClienteComponent implements OnInit {

  constructor(
    private router: Router,
    private clientesService: ClientesService,
    private activatedRoute: ActivatedRoute
  ) { }

  modelo: ClienteDto;
  errores: string[] = [];

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.clientesService.obtenerPorId(params.id)
        .subscribe(cliente => {
          this.modelo = cliente;
        }, () => this.router.navigate(['/']))
    });
  }

  guardarCambios(cliente: ClienteCreacionDto) {
    this.clientesService.editarCliente(this.modelo.idCliente, cliente)
      .subscribe(() => {
        this.router.navigate(['/']);
      }, error => console.log(error))
  }

}
