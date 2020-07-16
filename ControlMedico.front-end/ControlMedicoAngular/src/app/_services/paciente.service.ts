import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Paciente } from '../_models/paciente';

const API_URL = 'https://localhost:44322/api/pacientes/';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  constructor(private http: HttpClient) { }

  getPacientes(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(API_URL + 'ObtenerPacientes');
  }

  getPacientesPorCriterio(body) {
    return this.http.post(API_URL + 'ObtenerPorCriterio', body);
  }
}