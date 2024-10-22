export interface GenericResponse {
    code: number;
    data: any;
    mensage: string;
      
}

export interface ResponseSeguroEdad{
    Seguro: string,
    Limite:number
}

export interface ClienteResponse {
    idCliente: number;
    cedula: string;
    nombres: string;
    telefono?: string;
    edad: number;
    idEstado: string;
  }
  
