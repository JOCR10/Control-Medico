import { Paciente } from './paciente';

export class Cita {
    
        public IdCita: number;
        public FechaCita: Date;
        public IdPaciente: number;
        public TipoCita: EnumTipoCita;
        public DesTipoCita: string;
        public Cancelada: boolean;
        public InfoPaciente: Paciente;
    
}