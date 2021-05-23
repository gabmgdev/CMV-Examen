import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteCreacionDto } from '../ClienteDto';
import { ClientesService } from '../clientes.service';

@Component({
  selector: 'app-crear-cliente',
  templateUrl: './crear-cliente.component.html',
  styleUrls: ['./crear-cliente.component.css']
})
export class CrearClienteComponent implements OnInit {

  constructor(private router: Router, private clientesService: ClientesService) { }

  ngOnInit(): void {
  }

  guardarCambios(cliente: ClienteCreacionDto) {
    this.clientesService.crearCliente(cliente).subscribe(
      () => {
        this.router.navigate(['/']);
      },
      (error) => console.log(error)
    );
  }
}
