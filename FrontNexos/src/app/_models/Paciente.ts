import { Doctor } from './Doctor';

export interface Paciente {
    idPaciente: number;
    nombreCompleto: string;
    numSeguroSocial: number;
    codigoPostal: string;
    telefono: string;
    doctores: Doctor[];
}
