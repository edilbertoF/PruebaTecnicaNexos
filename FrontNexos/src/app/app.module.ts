import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { CRUDPacientesComponent } from './crud-pacientes/crud-pacientes.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { RegistrarPacienteComponent } from './registrar-paciente/registrar-paciente.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditarPacienteComponent } from './editar-paciente/editar-paciente.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegistrarDoctorComponent } from './registrar-doctor/registrar-doctor.component';
import { CrudDoctoresComponent } from './crud-doctores/crud-doctores.component';
import { EliminarPacientesComponent } from './eliminar-pacientes/eliminar-pacientes.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      CRUDPacientesComponent,
      HomeComponent,
      RegistrarPacienteComponent,
      EditarPacienteComponent,
      RegistrarDoctorComponent,
      CrudDoctoresComponent,
      EliminarPacientesComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      RouterModule.forRoot(appRoutes),
      ReactiveFormsModule,
      HttpClientModule,
      NgbModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
