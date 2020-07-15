import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'https://localhost:44322/api/pacientes/';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  constructor(private http: HttpClient) { }

  public getPacientes() {
    return this.http.get(API_URL + 'ObtenerPacientes');
  }

  public getPacientesPorCriterio(body) {
    return this.http.post(API_URL + 'ObtenerPorCriterio', body);
  }
}