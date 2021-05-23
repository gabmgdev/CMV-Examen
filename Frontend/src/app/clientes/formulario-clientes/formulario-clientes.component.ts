import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteCreacionDto } from '../ClienteDto';

@Component({
  selector: 'app-formulario-clientes',
  templateUrl: './formulario-clientes.component.html',
  styleUrls: ['./formulario-clientes.component.css']
})
export class FormularioClientesComponent implements OnInit {
  form: FormGroup;
  @Input() modelo: ClienteCreacionDto;
  @Output() guardarCambios: EventEmitter<ClienteCreacionDto> = new EventEmitter<ClienteCreacionDto>();

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(30)],
        },
      ],
      apellidoPaterno: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(30)],
        },
      ],
      apellidoMaterno: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(30)],
        },
      ],
      rfc: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(13), Validators.minLength(13)],
        },
      ],
      curp: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(18), Validators.minLength(18)],
        },
      ],
    });

    if (this.modelo !== undefined) {
      this.form.patchValue(this.modelo);
    }
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    this.guardarCambios.emit(this.form.value);
  }
}
