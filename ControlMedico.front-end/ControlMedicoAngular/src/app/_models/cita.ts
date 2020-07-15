import { Paciente } from './paciente';

export class Cita {
    IdCita: number;
    FechaCita: Date;
    IdPaciente: number;
    TipoCita: EnumTipoCita;
    DesTipoCita: string;
    Cancelada: boolean;
    InfoPaciente: Paciente;
}