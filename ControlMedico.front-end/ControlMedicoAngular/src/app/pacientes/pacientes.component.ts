import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Paciente } from '../_models/paciente';
import { PacienteService } from '../_services/paciente.service';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.css']
})
export class PacientesComponent implements OnInit, OnDestroy {
  content = '';
  subscription: Subscription;
  modeloPaciente: Paciente = new Paciente();
  pacientes: Paciente[];

  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {
    this.getAllPacientes();
  }

  ngOnDestroy() {
    this.subscription && this.subscription.unsubscribe();
  }

  public getPacientesFiltrado() {
    this.subscription = this.pacienteService.getPacientesPorCriterio(this.modeloPaciente)
      .subscribe
      (
        (result) => {
          this.pacientes = (result as Paciente[]);
        }
      );
  }
  public getAllPacientes() {
    this.subscription = this.pacienteService.getPacientes()
      .subscribe
      (
        (result) => {
          this.pacientes = (result as Paciente[]);
        }
      );
  }

  onClickSubmit(buttonType) {
    if (buttonType === "Buscar") {
      this.getPacientesFiltrado()
    }
  }

  public showAlert() {
    alert("You should fill the corresponding data based on the selected filter.");
  }
}