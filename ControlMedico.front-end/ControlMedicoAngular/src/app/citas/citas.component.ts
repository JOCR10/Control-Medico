import { Component, OnInit, OnDestroy } from '@angular/core';
import { CitaService } from '../_services/cita.service';
import { Subscription } from 'rxjs/internal/Subscription';
import { Cita } from '../_models/cita';


@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent implements OnInit, OnDestroy {
  content = '';
  subscription: Subscription;
  modeloCita: Cita;
  citas: Cita[] = [];
  citaCancelada: boolean;
  citaRegistrada: boolean;

  constructor(private citaService: CitaService) { }

  ngOnInit() {
    this.getAllCitas();
  }

  ngOnDestroy() {
    this.subscription && this.subscription.unsubscribe();
  }

  public getCitasFiltrado() {
    this.subscription = this.citaService.getCitasPorCriterio(this.modeloCita)
      .subscribe
      (
        (result) => {
          this.citas = (result as Cita[]);
        }
      );
  }

  public RegistrarCita() {
    this.subscription = this.citaService.RegistrarCita(this.modeloCita)
      .subscribe
      (
        (result) => {
          this.citaRegistrada = (result as boolean);
        }
      );
  }

  public CancelarCita() {
    this.subscription = this.citaService.CancelarCita(this.modeloCita)
      .subscribe
      (
        (result) => {
          this.citaCancelada = (result as boolean);
        }
      );
  }
  public getAllCitas() {
    this.subscription = this.citaService.getCitas()
      .subscribe
      (
        (result) => {
          this.citas = (result as Cita[]);
        }
      );
  }

  onClickSubmit() {
    this.getCitasFiltrado()
  }

  onClickRegistrarCita() {
    this.RegistrarCita()
  }

  onClickCancelarCita() {
    this.CancelarCita()
  }

  public showAlert() {
    alert("");
  }
}