import { Paciente } from './Paciente';

export interface Doctor {
    idDoctor: number;
    nombreCompleto: string;
    especialidad: string;
    numeroCredencial: number;
    hospitalTrabaja: string;
    pacientes: Paciente[];
}
