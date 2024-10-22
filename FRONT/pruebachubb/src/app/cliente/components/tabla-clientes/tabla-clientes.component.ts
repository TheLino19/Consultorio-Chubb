import { Component, Input } from '@angular/core';
import { ClienteResponse } from '../../interfaces/response/genericResponse';
import { Cliente } from '../../interfaces/cliente';

@Component({
  selector: 'app-tabla-clientes',
  templateUrl: './tabla-clientes.component.html',
  styleUrl: './tabla-clientes.component.css'
})
export class TablaClientesComponent {
  @Input() clientes?: ClienteResponse [] = [];
  cliente?: ClienteResponse ;

eliminarCliente(arg0: number) {
throw new Error('Method not implemented.');
}
editarCliente(_t14: ClienteResponse) {
throw new Error('Method not implemented.');
}
 
}
