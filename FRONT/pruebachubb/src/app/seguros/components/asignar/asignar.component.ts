import { Component } from '@angular/core';
import { ClienteExcel } from '../../interfaces/seguros-response';
import { SeguroService } from '../../services/seguro.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-asignar',
  templateUrl: './asignar.component.html',
  styleUrl: './asignar.component.css'
})
export class AsignarComponent {

  constructor(private _service: SeguroService ){

  }
  filePath: string = 'C:/Users/VivoBook/Documents/practicas Viamatica/NET/prueba seguro chupp/API_SEGUROS_CHUPP';
  clienteExcel:ClienteExcel[]=[];
  onFileSelected(event: any): void {
    if (event.target.files.length > 0) {
      
      const fileName = event.target.files[0].name;
      this.filePath = `${this.filePath}/${fileName}`;
      this.cargarArchivos(this.filePath);
    }
  }

  cargarArchivos(path:string){
    this._service.obtenerExcel(path).subscribe({next:r=>{
      if(r.code == 200){
        this.clienteExcel = r.data as ClienteExcel[];
      }
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
