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
  model: Paciente = new Paciente();
  public pacientes:Paciente[] = [];
  
  

  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {
    this.getAllPacientes();
  }

  ngOnDestroy() {
    this.subscription && this.subscription.unsubscribe();
  }

  public getPacientesFiltrado() {
    this.subscription = this.pacienteService.getPacientesPorCriterio(this.model)
      .subscribe
      (
        (result: any[]) => {
          debugger;
          this.pacientes = result;
        }
      );
  }
  public getAllPacientes() {
    this.subscription = this.pacienteService.getPacientes()
      .subscribe
      (
        (result: any[]) => {
          debugger;
          console.log(result);
          this.pacientes = result;
          
          console.log(this.pacientes);
        }
      );
  }

  onClickSubmit() {
      this.getPacientesFiltrado()
  }

  public showAlert() {
    alert("You should fill the corresponding data based on the selected filter.");
  }
}