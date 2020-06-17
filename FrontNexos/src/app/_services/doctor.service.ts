import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Doctor } from '../_models/Doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  register(doctor: Doctor) {
    return this.http.post(this.baseUrl + 'Doctor', doctor);
  }

  consultarDoctor(id: number) {
    return this.http.get(this.baseUrl + 'Doctor/' + id);
  }

  getDoctores() {
    return this.http.get(this.baseUrl + 'Doctor/getdoctores');
  }

  actualizarDoctor(id: number, doctorActualizar: Doctor) {
    return this.http.put(this.baseUrl + 'Doctor/ActualizarDoctor/' + id, doctorActualizar);
  }

  eliminarDoctor(id: number) {
    return this.http.delete(this.baseUrl + 'Doctor/EliminarDoctor/' + id);
  }

}
