import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'https://localhost:44322/api/citas/';

@Injectable({
  providedIn: 'root'
})
export class CitaService {

  constructor(private http: HttpClient) { }

  public getCitas() {
    return this.http.get(API_URL + 'ObtenerCitas');
  }

  public getCitasPorCriterio(body) {
    return this.http.post(API_URL + 'ObtenerCitasPorCriterio', body);
  }

  public RegistrarCita(body) {
    return this.http.post(API_URL + 'RegistrarCita', body);
  }

  public CancelarCita(body) {
    return this.http.post(API_URL + 'CancelarCita', body);
  }
}