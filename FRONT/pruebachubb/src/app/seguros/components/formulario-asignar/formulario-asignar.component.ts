import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ClienteExcel } from '../../interfaces/seguros-response';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteServiceService } from '../../../cliente/services/cliente-service.service';
import { ResponseSeguroEdad } from '../../../cliente/interfaces/response/genericResponse';
import { catchError, map, Observable, of } from 'rxjs';

@Component({
  selector: 'app-formulario-asignar',
  templateUrl: './formulario-asignar.component.html',
  styleUrl: './formulario-asignar.component.css'
})
export class FormularioAsignarComponent implements OnChanges {
  isCedulaDisabled: boolean = false; 
  clienteForm: FormGroup;
  seguros: ResponseSeguroEdad[] = [];
  @Input() clienteExcel?: ClienteExcel;
  constructor(private fb: FormBuilder, private _service: ClienteServiceService) {
    this.clienteForm = this.fb.group({
      cedula: ['', Validators.required],
      nombres: ['', Validators.required],
      telefono: ['', Validators.required],
      edad: ['', [Validators.required, Validators.min(0)]]
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['clienteExcel'] && this.clienteExcel) {
      this.clienteForm.patchValue({
        cedula: this.clienteExcel.cedula,
        nombres: this.clienteExcel.nombres,
        telefono: this.clienteExcel.telefono,
        edad: this.clienteExcel.edad
      });
    }
    this.onInputChange();
    this.buscarCedula();
  }


  onRegister() {
    throw new Error('Method not implemented.');
  }


  onInputChange(): void {

    this._service.seguroEdad(this.clienteForm.get('edad')?.value).subscribe({
      next: r => {
        this.seguros = [];
        if (r.code == 200) {

          this.seguros = r.data as ResponseSeguroEdad[];
        }
      }

    });
  }

  
buscarCedula(): void {
  this._service.buscarPorCedula(this.clienteForm.get('cedula')?.value).subscribe({
    next: r => {
      if (r.code == -1) {
        this.isCedulaDisabled = false; // Deshabilitar el campo si la cédula no se encuentra
      } else {
        this.isCedulaDisabled = true; // Habilitar si se encuentra
      }
    },
    error: () => {
      this.isCedulaDisabled = false; // Manejo de error, habilitar campo
    }
  });
}
  
}
