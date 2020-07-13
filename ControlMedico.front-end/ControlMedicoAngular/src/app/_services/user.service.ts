import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = 'https://localhost:44322/api/pacientes/';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getPacientes(): Observable<any> {
    return this.http.get(API_URL + 'ObtenerPacientes', { responseType: 'text' });
  }

  getCitas(): Observable<any> {
    return this.http.get(API_URL + 'ObtenerCitas', { responseType: 'text' });
  }
}