import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../interfaces/cliente';
import { GenericResponse } from '../interfaces/response/genericResponse';

@Injectable({
  providedIn: 'root'
})
export class ClienteServiceService {
  private apiUrl = 'http://localhost:5051/api/Cliente/'; 
  private apiUrlValidacion = 'http://localhost:5051/api/ValidacionControlller/'; 
  constructor(private http: HttpClient) { }

  registerCliente(cliente: Cliente): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}CrearCliente`, cliente);
  }
  seguroEdad(edad: number): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrlValidacion}SeguroPorEdad`, edad);
  }
  
  obtenerClientes(): Observable<GenericResponse> {
    return this.http.get<GenericResponse>(`${this.apiUrl}ObtenerClientes`);
  }

  buscarPorCedula(cedula : string){
    return this.http.post<GenericResponse>(`${this.apiUrl}CrearCliente`,cedula);
  }
  
}
