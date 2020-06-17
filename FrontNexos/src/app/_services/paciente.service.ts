import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Paciente } from '../_models/Paciente';
import { HttpClient } from '@angular/common/http';
import { PacienteActualizar } from '../_models/PacienteActualizar';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

register(paciente: Paciente) {
  return this.http.post(this.baseUrl + 'Paciente', paciente);
}

consultarPaciente(id: number) {
  return this.http.get(this.baseUrl + 'Paciente/' + id);
}

getPacientes() {
  return this.http.get(this.baseUrl + 'Paciente/getpacientes');
}

actualizarPaciente(id: number, pacienteActualizar: Paciente) {
  return this.http.put(this.baseUrl + 'Paciente/ActualizarPaciente/' + id, pacienteActualizar);
}

eliminarPaciente(id: number) {
  return this.http.delete(this.baseUrl + 'Paciente/EliminarPaciente/' + id);
}

}
