import { EnumTipoIdentificacion, EnumGenero } from './enumerados';

export class Paciente {
        public IdPaciente: number;
        public Identificacion: string;
        public TipoIdentificacion: EnumTipoIdentificacion;
        public DesTipoIdentificacion: string;
        public NombreCompleto: string;
        public FechaNacimiento: Date;
        public Genero: EnumGenero;
        public DesGenero: string;
        public Residencia: string;
        public Telefono: string;
}