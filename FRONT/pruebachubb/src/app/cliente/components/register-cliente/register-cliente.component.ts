import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteServiceService } from '../../services/cliente-service.service';
import { Cliente } from '../../interfaces/cliente';
import Swal from 'sweetalert2'; 
import { ClienteResponse, ResponseSeguroEdad } from '../../interfaces/response/genericResponse';


@Component({
  selector: 'app-register-cliente',
  templateUrl: './register-cliente.component.html',
  styleUrl: './register-cliente.component.css',
  
})
export class RegisterClienteComponent {
  clienteForm: FormGroup;
  
  clientes: ClienteResponse[] = [];

  constructor(private fb: FormBuilder,private _service: ClienteServiceService ) {
    this.clienteForm = this.fb.group({
      cedula: ['', Validators.required],
      nombres: ['', Validators.required],
      telefono: ['', Validators.required],
      edad: ['', [Validators.required, Validators.min(0)]]
    });
    this.getClientes();
  }

  onRegister() {
    if (this.clienteForm.valid) {
      console.log(this.clienteForm.value);
      const cliente: Cliente = this.clienteForm.value as Cliente;
      this._service.registerCliente(cliente).subscribe({next:r=>{
        
        Swal.fire({
          icon: 'success',
          title: r.mensage,
          confirmButtonText: 'Aceptar'
        });
      },
      error :error => {
        console.error('Error registering user', error);
      }
    
    });
    }
  }

  

  getClientes(){
    this.clientes = [];
    this._service.obtenerClientes().subscribe({next:r=>{
      if(r.code == 200){
        this.clientes = r.data as ClienteResponse[];
      }
    }})
  }
}

