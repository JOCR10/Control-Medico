export class Paciente {
    IdPaciente: number;
    Identificacion: string;
    TipoIdentificacion: EnumTipoIdentificacion;
    DesTipoIdentificacion: string;
    NombreCompleto: string;
    FechaNacimiento: Date;
    Genero: EnumGenero;
    DesGenero: string;
    Residencia: string;
    Telefono: string;
}