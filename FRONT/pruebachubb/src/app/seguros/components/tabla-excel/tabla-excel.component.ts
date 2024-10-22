import { Component, Input } from '@angular/core';
import { ClienteExcel } from '../../interfaces/seguros-response';
import { ClienteServiceService } from '../../../cliente/services/cliente-service.service';

@Component({
  selector: 'app-tabla-excel',
  templateUrl: './tabla-excel.component.html',
  styleUrl: './tabla-excel.component.css'
})
export class TablaExcelComponent {
  @Input() clienteExcel: ClienteExcel[] = [];
  cliente?:ClienteExcel;
  constructor(private _service: ClienteServiceService){}
  cargarClientes(){
    this.clienteExcel =[];
    this._service.obtenerClientes().subscribe({next:r=>{
      if(r.code == 200){
        this.clienteExcel = r.data as ClienteExcel[];
      }
    }})
  }

  asignarSeguro(cliente :ClienteExcel){
    this.cliente = cliente;
  }
}
