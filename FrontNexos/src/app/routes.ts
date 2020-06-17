import {Routes} from '@angular/router';
import { CRUDPacientesComponent } from './crud-pacientes/crud-pacientes.component';
import { HomeComponent } from './home/home.component';
import { RegistrarPacienteComponent } from './registrar-paciente/registrar-paciente.component';
import { EditarPacienteComponent } from './editar-paciente/editar-paciente.component';
import { CrudDoctoresComponent } from './crud-doctores/crud-doctores.component';
import { EliminarPacientesComponent } from './eliminar-pacientes/eliminar-pacientes.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        children: [
            { path: 'CRUDPacientes', component: CRUDPacientesComponent},
            { path: 'CRUDDoctores', component: CrudDoctoresComponent},
            { path: 'registrar-paciente', component: RegistrarPacienteComponent},
            { path: 'editarPacientes', component: EditarPacienteComponent},
            { path: 'eliminarPacientes', component: EliminarPacientesComponent}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

