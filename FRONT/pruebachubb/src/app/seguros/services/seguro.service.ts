import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericResponse } from '../../cliente/interfaces/response/genericResponse';
import { Observable } from 'rxjs';
import { SeguroRequest } from '../interfaces/seguros-response';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {
  private apiUrl = 'http://localhost:5051/api/Seguros/'; 
  private excelUrl = 'http://localhost:5051/api/Cliente/';
  constructor(private http: HttpClient) { }

  obtenerSeguros(): Observable<GenericResponse> {
    return this.http.get<GenericResponse>(`${this.apiUrl}ObtenerSeguros`);
  }
  crearSeguro(seguro:SeguroRequest): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}CrearSeguro`,seguro);
  }

  eliminarSeguro(id: number): Observable<GenericResponse> {
    return this.http.request<GenericResponse>('DELETE', `${this.apiUrl}eliminarSeguro`, {
      body: { id }, // El cuerpo donde se envía el ID
      observe: 'body' // Se asegura de que se observe el cuerpo de la respuesta
    });
  }

  modificarSeguro(seguro:SeguroRequest): Observable<GenericResponse> {
    return this.http.put<GenericResponse>(`${this.apiUrl}editarSeguro`,seguro);
  }

  obtenerExcel(path:string):Observable<GenericResponse>{
    return this.http.post<GenericResponse>(`${this.excelUrl}obtenerExcel`,{ ruta: path });
  }
  
  
}
