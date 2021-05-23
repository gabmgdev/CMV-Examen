import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from './material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { FormularioClientesComponent } from './clientes/formulario-clientes/formulario-clientes.component';
import { ClientesListaComponent } from './clientes/clientes-lista/clientes-lista.component';
import { EditarClienteComponent } from './clientes/editar-cliente/editar-cliente.component';
import { ClientesCuentasComponent } from './clientes/clientes-cuentas/clientes-cuentas.component';
import { CrearClienteComponent } from './clientes/crear-cliente/crear-cliente.component';

@NgModule({
  declarations: [
    AppComponent,
    FormularioClientesComponent,
    ClientesListaComponent,
    EditarClienteComponent,
    FormularioClientesComponent,
    ClientesCuentasComponent,
    CrearClienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    SweetAlert2Module.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
