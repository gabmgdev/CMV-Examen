import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesCuentasComponent } from './clientes/clientes-cuentas/clientes-cuentas.component';
import { ClientesListaComponent } from './clientes/clientes-lista/clientes-lista.component';
import { CrearClienteComponent } from './clientes/crear-cliente/crear-cliente.component';
import { EditarClienteComponent } from './clientes/editar-cliente/editar-cliente.component';

const routes: Routes = [
  {
    path: '', component: ClientesListaComponent
  },
  { path: 'clientes/editar/:id', component: EditarClienteComponent },
  { path: 'clientes/crear', component: CrearClienteComponent },
  { path: 'clientes/:id/cuentas', component: ClientesCuentasComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
