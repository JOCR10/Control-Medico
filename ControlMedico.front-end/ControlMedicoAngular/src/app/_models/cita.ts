import { Paciente } from './paciente';
import { EnumTipoCita } from './enumerados';

export class Cita {
    
        public IdCita: number;
        public FechaCita: Date;
        public IdPaciente: number;
        public TipoCita: EnumTipoCita;
        public DesTipoCita: string;
        public Cancelada: boolean;
        public InfoPaciente: Paciente;
    
}